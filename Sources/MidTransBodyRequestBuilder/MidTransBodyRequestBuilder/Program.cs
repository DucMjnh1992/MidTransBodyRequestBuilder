using MidTrans.Core;
using MidTrans.Core.Adapter;
using MidTrans.Core.Builder;
using MidTrans.Core.Common;
using MidTrans.Core.Models;
using System;
using System.Collections.Generic;
using System.Net;

namespace MidTransBodyRequestBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = Config.MidTransCreditCardInstallmentTermBca;
            Console.ReadKey();
            return;
            #region Build full midtrans body reuqest 

            BodyRequest bodyRequest = BodyRequestBuilder
                .CreateInstance()
                .SetTransactionDetail(TransactionDetailBuilder
                    .CreateInstance()
                    .SetOrderId("ORDER-107")
                    .SetGrossAmount(1)
                    .Build()
                )
                .AddItemToItemDetailsUnique(ItemDetailBuilder
                    .CreateInstance()
                    .SetId("ITEM1")
                    .SetPrice(1)
                    .SetQuantity(1)
                    .SetName("Midtrans Bear")
                    .Build()
                )
                .AddItemToItemDetailsUnique(ItemDetailBuilder
                    .CreateInstance()
                    .SetId("ITEM2")
                    .SetPrice(1)
                    .SetQuantity(2)
                    .SetName("Midtrans Bear 2")
                    .Build()
                )
                .AddItemToEnabledPaymentsUnique("credit_card")
                .AddItemToEnabledPaymentsUnique("mandiri_clickpay")
                .SetCreditCard(CreditCardBuilder.CreateInstance()
                    .SetSecure(true)
                    .SetChannel("migs")
                    .SetBank("bca")
                    .SetInstallment(InstallmentBuilder
                        .CreateInstance()
                        .SetRequired(false)
                        .SetTerm(TermBuilder
                            .CreateInstance()
                            .AddItemToBnisUnique(3)
                            .AddItemToBnisUnique(6)
                            .AddItemToBnisUnique(12)
                            .SetBnis(new List<int>()
                            {
                                3,
                                6,
                                12
                            })
                            .AddItemToCimbsUnique(3)
                            .AddItemToBcasUnique(3)
                            .AddItemToBcasUnique(6)
                            .AddItemToBcasUnique(12)
                            .AddItemToOfflinesUnique(6)
                            .AddItemToOfflinesUnique(12)
                            .Build()
                        )
                        .Build()
                    )
                    .AddItemToWhitelistBinsUnique("48111111")
                    .AddItemToWhitelistBinsUnique("41111111")
                    .Build()
                )
                .SetCustomerDetail(CustomerDetailBuilder
                    .CreateInstance()
                    .SetFirstName("TEST")
                    .SetLastName("MIDTRANSER")
                    .SetEmail("phung.nguyen.duc.minh@miyatsu.vn")
                    .SetPhone("+628123456")
                    .SetBillingAddress(AddressDetailBuilder
                        .CreateInstance()
                        .SetFirstName("TEST")
                        .SetLastName("MIDTRANSER")
                        .SetEmail("test@midtrans.com")
                        .SetPhone("081 2233 44-55")
                        .SetAddress("Sudirman")
                        .SetCity("Jakarta")
                        .SetPostalCode("12190")
                        .SetCountryCode("IDN")
                        .Build()
                    )
                    .SetShippingAddress(AddressDetailBuilder
                        .CreateInstance()
                        .SetFirstName("TEST")
                        .SetLastName("MIDTRANSER")
                        .SetEmail("test@midtrans.com")
                        .SetPhone("0 8128-75 7-9338")
                        .SetAddress("Sudirman")
                        .SetCity("Jakarta")
                        .SetPostalCode("12190")
                        .SetCountryCode("IDN")
                        .Build()
                    )
                    .Build()
                )
                .SetExpiry(ExpiryBuilder
                    .CreateInstance()
                    .SetStartTime("2017-04-13 18:11:08 +0700")
                    .SetUnit("minutes")
                    .SetDuration(1)
                    .Build()
                 )
                .Build();

            string json = BodyRequestAdapter.Instance.ConvertToJson(bodyRequest);

            Console.WriteLine(json);

            #endregion Build full midtrans body reuqest

            //#region Build short midtrans body reuqest 

            bodyRequest = BodyRequestBuilder
                .CreateInstance()
                .SetTransactionDetail(TransactionDetailBuilder
                    .CreateInstance()
                    .SetOrderId("ORDER-111")
                    .SetGrossAmount(1)
                    .Build()
                )
                //.AddItemToEnabledPaymentsUnique("credit_card")
                //.SetCustomerDetail(CustomerDetailBuilder
                //    .CreateInstance()
                //    .SetEmail("phung.nguyen.duc.minh@miyatsu.vn")
                //    .SetPhone("+628123456")
                //    .Build()
                //)
                .Build();

            json = BodyRequestAdapter.Instance.ConvertToJson(bodyRequest);

            Console.WriteLine(json);

            //#endregion Build full midtrans body reuqest

            //RequestMethod requestMethod = new RequestMethod();
            //System.Net.HttpWebRequest request = requestMethod.getRequest("POST", "application/json", "https://app.sandbox.midtrans.com/snap/v1/transactions", json) as System.Net.HttpWebRequest;
            //System.Net.WebResponse response = request.GetResponse();
            //string result = requestMethod.UnPackResponse(response);

            //RequestMethod requestMethod = RequestMethod.CreateInstance();
            //requestMethod.CreateRequest(Config.EndpointSandboxOrProductionByIsProduction);
            //requestMethod.Request.Method = Config.MidTransEndPointMethod;
            //requestMethod.Request.Accept = Config.MidTransRequestHeaderAccept;
            //requestMethod.Request.ContentType = Config.MidTransRequestHeaderContentType;
            //requestMethod.Request.UseDefaultCredentials = true;
            //requestMethod.Request.PreAuthenticate = true;
            //requestMethod.Request.Credentials = CredentialCache.DefaultCredentials;

            //requestMethod.Request.Headers.Add("Authorization", Config.MidTransAuthorization);
            //requestMethod.WriteContent(json);
            //requestMethod.GetResponse();

            //string result = requestMethod.UnPackResponse();
            //Response response = ResponseAdapter.Instance.ConvertFromJson(result);
            //response.StatusCode = requestMethod.Response.StatusCode;

            //if (response.IsResponseSuccess)
            //{
            //    Console.WriteLine($"Request is successful, token: {response.Token}");
            //}
            //else
            //{
            //    Console.WriteLine($"Request fail, status code = {response.StatusCode}, error messages: ");

            //    foreach (string item in response.ErrorMessages)
            //    {
            //        Console.WriteLine(item);
            //    }
            //}

            Response response = MidtransRequest.CreateInstance(bodyRequest).Send();

            if (response.IsResponseSuccess)
            {
                Console.WriteLine($"Request is successful, token: {response.Token}");
            }
            else
            {
                Console.WriteLine($"Request fail, status code = {response.StatusCode}, error messages: ");

                foreach (string item in response.ErrorMessages)
                {
                    Console.WriteLine(item);
                }
            }

            Console.ReadKey();
        }
    }
}