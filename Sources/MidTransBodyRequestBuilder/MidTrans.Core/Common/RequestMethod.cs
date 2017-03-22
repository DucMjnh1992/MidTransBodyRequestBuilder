using System.IO;
using System.Net;
using System.Text;

namespace MidTrans.Core.Common
{
    public class RequestMethod
    {
        public WebRequest getRequest(string method, string contentType, string endPoint, string content)
        {
            var request = this.getRequest(method, contentType, endPoint);
            var dataArray = Encoding.UTF8.GetBytes(content.ToString());

            request.ContentLength = dataArray.Length;

            var requestStream = request.GetRequestStream();

            requestStream.Write(dataArray, 0, dataArray.Length);
            requestStream.Flush();
            requestStream.Close();

            return request;
        }

        public WebRequest getRequest(string method, string contentType, string endPoint)
        {
            var request = WebRequest.Create(endPoint);

            request.Method = method;
            request.ContentType = contentType;
            request.Timeout = 600000;// set for 3 min by subbu default is 100000 milli sec

            request.UseDefaultCredentials = true;
            request.PreAuthenticate = true;
            request.Credentials = CredentialCache.DefaultCredentials;

            request.Headers.Add("Authorization", "Basic VlQtc2VydmVyLWRqX09ucW9NTXpMYzJQUnhaSzljS2Nxajo=");

            return request;
        }


        public Stream GetResponseStream(WebResponse response)
        {
            return response.GetResponseStream();
        }

        public StreamReader GetResponseReader(WebResponse response)
        {
            return new StreamReader(GetResponseStream(response));
        }

        public string UnPackResponse(WebResponse response)
        {
            return GetResponseReader(response).ReadToEnd();
        }
    }
}
