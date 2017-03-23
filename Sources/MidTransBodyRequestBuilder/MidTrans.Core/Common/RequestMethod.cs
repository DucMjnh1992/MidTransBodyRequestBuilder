using System;
using System.IO;
using System.Net;
using System.Text;

namespace MidTrans.Core.Common
{
    public class RequestMethod
    {
        public HttpWebRequest Request { get; private set; }
        public HttpWebResponse Response { get; private set; }

        public static RequestMethod CreateInstance()
        {
            return new RequestMethod();
        }

        public HttpWebRequest CreateRequest(string endpoint)
        {
            this.Request = WebRequest.Create(endpoint) as HttpWebRequest;

            return this.Request;
        }

        public HttpWebRequest WriteContent(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
            {
                throw new ArgumentNullException(nameof(content));
            }

            byte[] contentBytes = Encoding.UTF8.GetBytes(content);
            this.Request.ContentLength = contentBytes.Length;
            Stream requestStream = this.Request.GetRequestStream();

            requestStream.Write(contentBytes, 0, contentBytes.Length);
            requestStream.Flush();
            requestStream.Close();

            return this.Request;
        }

        public HttpWebResponse GetResponse()
        {
            this.Response = this.Request.GetResponse() as HttpWebResponse;

            return this.Response;
        }

        public StreamReader GetResponseReader()
        {
            Stream responseStream = this.Response.GetResponseStream();
            StreamReader responseStreamReader = new StreamReader(responseStream);

            return responseStreamReader;
        }

        public string UnPackResponse()
        {
            StreamReader responseStreamReader = this.GetResponseReader();
            string result = responseStreamReader.ReadToEnd();

            return result;
        }
    }
}
