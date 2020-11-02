using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace wbam.mypages.Services
{
    public class BaseService
    {
        protected static HttpClient Client { get; private set; }
        protected static readonly string baseUrl = "http://ec2-3-129-59-197.us-east-2.compute.amazonaws.com:3100/bamapi/v1";

        public BaseService()
        {
            if (Client == null)
            {
                Client = new HttpClient();
                Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                Client.BaseAddress = new Uri(baseUrl);
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11;
            }
        }
    }
}