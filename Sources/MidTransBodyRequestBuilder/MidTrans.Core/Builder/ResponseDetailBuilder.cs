using MidTrans.Core.Models;
using System.Collections.Generic;
using System.Net;

namespace MidTrans.Core.Builder
{
    public class ResponseBuilder : BaseBuilder<Response>, IBuilder<Response>
    {
        private HttpStatusCode statusCode;
        private string token { get; set; }
        private IList<string> errorMessages;

        public ResponseBuilder()
            : base(null)
        {
        }
        
        public ResponseBuilder(Response model)
            : base(model)
        {            
        }

        public static ResponseBuilder CreateInstance()
        {
            return new ResponseBuilder();
        }

        public static ResponseBuilder CreateInstance(Response model)
        {
            return new ResponseBuilder(model);
        }

        public ResponseBuilder SetModel(Response model)
        {
            this.model = model;

            return this;
        }

        public ResponseBuilder SetStatusCode(HttpStatusCode statusCode)
        {
            this.statusCode = statusCode;

            return this;
        }

        public ResponseBuilder SetGrossAmount(string token)
        {
            this.token = token;

            return this;
        }

        public ResponseBuilder SetErrorMessages(IList<string> errorMessages)
        {
            this.errorMessages = errorMessages;

            return this;
        }

        public ResponseBuilder AddItemToErrorMessages(string item)
        {
            this.errorMessages = this.AddToCollection<string>(this.errorMessages, item);

            return this;
        }

        public ResponseBuilder AddItemToErrorMessagesUnique(string item)
        {
            this.errorMessages = this.AddToCollectionUnique<string>(this.errorMessages, item, this.StringEquals);

            return this;
        }

        public override Response Build()
        {
            this.model = this.model ?? new Response();

            this.model.StatusCode = this.statusCode;
            this.model.Token = this.token;
            this.model.ErrorMessages = this.errorMessages;

            return this.model;
        }
    }
}
