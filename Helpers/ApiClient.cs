using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFStest.Helpers
{
    public class ApiClient
    {
        private readonly RestClient _client;

        public ApiClient()
        {
            _client = new RestClient("https://petstore.swagger.io/v2/");
        }

        public RestResponse ExecutePost(string resource, object body)
        {
            var req = new RestRequest(resource, Method.Post).AddJsonBody(body);
            return _client.ExecuteAsync(req).GetAwaiter().GetResult();
        }

        public RestResponse ExecuteGet(string resource)
        {
            var req = new RestRequest(resource, Method.Get);
            return _client.ExecuteAsync(req).GetAwaiter().GetResult();
        }

        public RestResponse ExecutePut(string resource, object body)
        {
            var req = new RestRequest(resource, Method.Put).AddJsonBody(body);
            return _client.ExecuteAsync(req).GetAwaiter().GetResult();
        }

        public RestResponse ExecuteDelete(string resource)
        {
            var req = new RestRequest(resource, Method.Delete);
            return _client.ExecuteAsync(req).GetAwaiter().GetResult();
        }
    }
}
