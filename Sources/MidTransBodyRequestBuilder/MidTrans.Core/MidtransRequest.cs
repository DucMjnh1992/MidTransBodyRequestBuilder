using MidTrans.Core.Adapter;
using MidTrans.Core.Builder;
using MidTrans.Core.Common;
using MidTrans.Core.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;

namespace MidTrans.Core
{
    public class MidtransRequest
    {
        private const string DETECT_EXCEPTION_MESSAGE_DEFAULT = "Something went wrong!";
        private readonly static IDictionary<HttpStatusCode, string> messages = new Dictionary<HttpStatusCode, string>()
        {
            //400
            { HttpStatusCode.BadRequest, "Bad request." },
            //401
            { HttpStatusCode.Unauthorized, "Access denied, please check client or server key." },
            //500
            { HttpStatusCode.InternalServerError, "Sorry, we encountered internal server error. We will fix this soon." }
        };

        public BodyRequest BodyRequest { get; set; }
        public Response Response { get; private set; }

        public MidtransRequest()
            : this(null)
        {
        }

        public MidtransRequest(BodyRequest bodyRequest)
        {
            this.BodyRequest = bodyRequest;
        }

        public static MidtransRequest CreateInstance(BodyRequest bodyRequest)
        {
            return new MidtransRequest(bodyRequest);
        }

        public static MidtransRequest CreateInstance()
        {
            return new MidtransRequest();
        }

        private void Validate(BodyRequest bodyRequest)
        {
            if (bodyRequest == null)
            {
                throw new ArgumentNullException(nameof(bodyRequest));
            }

            if (bodyRequest.TransactionDetail == null)
            {
                throw new ArgumentNullException("Transaction can not be null.");
            }

            if (string.IsNullOrWhiteSpace(bodyRequest.TransactionDetail.OrderId))
            {
                throw new ArgumentNullException("Order id is required.");
            }

            if (bodyRequest.TransactionDetail.GrossAmount <= 0)
            {
                throw new Exception("Gross amount is required and have must greater than 0");
            }
        }

        private void DetectException(WebException ex)
        {
            this.Response = ResponseBuilder
                .CreateInstance(this.Response)
                .Build();

            if (ex == null)
            {
                return;
            }

            HttpWebResponse webResponse = ex.Response as HttpWebResponse;

            if (webResponse == null)
            {
                this.Response = ResponseBuilder
                    .CreateInstance(this.Response)
                    .AddItemToErrorMessagesUnique(ex.Message)
                    .Build();

                return;
            }
            
            HttpStatusCode statusCode = webResponse.StatusCode;

            if (!messages.ContainsKey(statusCode))
            {
                this.Response = ResponseBuilder
                    .CreateInstance(this.Response)
                    .AddItemToErrorMessagesUnique(DETECT_EXCEPTION_MESSAGE_DEFAULT)
                    .Build();

                return;
            }

            this.Response = ResponseBuilder
                    .CreateInstance(this.Response)
                    .SetStatusCode(statusCode)
                    .AddItemToErrorMessagesUnique(messages[statusCode])
                    .Build();
        }

        private Response GetResponse(string jsonContent)
        {
            try
            {
                RequestMethod requestMethod = RequestMethod.CreateInstance();

                requestMethod.CreateRequest(Config.EndpointSandboxOrProductionByIsProduction);

                requestMethod.Request.Method = Config.MidTransEndPointMethod;
                requestMethod.Request.Accept = Config.MidTransRequestHeaderAccept;
                requestMethod.Request.ContentType = Config.MidTransRequestHeaderContentType;
                requestMethod.Request.UseDefaultCredentials = true;
                requestMethod.Request.PreAuthenticate = true;
                requestMethod.Request.Credentials = CredentialCache.DefaultCredentials;

                requestMethod.Request.Headers.Add("Authorization", Config.MidTransAuthorization);
                requestMethod.WriteContent(jsonContent);
                requestMethod.GetResponse();

                string result = requestMethod.UnPackResponse();
                this.Response = ResponseAdapter.Instance.ConvertFromJson(result);
                this.Response.StatusCode = requestMethod.Response.StatusCode;

                return this.Response;
            }
            catch (WebException ex)
            {
                this.DetectException(ex);
            }
            catch (Exception ex)
            {
                this.Response = ResponseBuilder
                    .CreateInstance(this.Response)
                    .AddItemToErrorMessagesUnique(ex.Message)
                    .Build();
            }

            return this.Response;
        }

        public Response Send(BodyRequest bodyRequest)
        {
            this.Validate(bodyRequest);

            this.BodyRequest = bodyRequest;
            string bodyRequestJson = BodyRequestAdapter.Instance.ConvertToJson(bodyRequest);
            this.GetResponse(bodyRequestJson);

            return this.Response;
        }

        public Response Send()
        {
            this.Send(this.BodyRequest);

            return this.Response;
        }
    }
}
