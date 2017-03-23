using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;

namespace MidTrans.Core.Models
{
    public class Response
    {
        public bool IsResponseSuccess
        {
            get
            {
                bool tokenIsEmpty = string.IsNullOrWhiteSpace(this.Token);
                bool errorMessageIsEmpty = this.ErrorMessages == null || this.ErrorMessages.Count == 0;

                if (tokenIsEmpty && errorMessageIsEmpty)
                {
                    return false;
                }

                if (tokenIsEmpty)
                {
                    return false;
                }

                return true;
            }
        }

        public HttpStatusCode StatusCode { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("error_messages")]
        public IList<string> ErrorMessages { get; set; }
    }
}
