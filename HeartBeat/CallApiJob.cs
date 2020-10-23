using Quartz;
using RestSharp;
using System;
using System.Configuration;
using System.Threading.Tasks;

namespace HeartBeat
{
    public class CallApiJob : IJob
    {
        
        public async Task Execute(IJobExecutionContext context)
        {
            var client = new RestClient(ConfigurationManager.AppSettings["endpoint"]);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", $"Bearer {ConfigurationManager.AppSettings["bearer"]}");
            request.AddParameter("text/plain", "", ParameterType.RequestBody);
            IRestResponse response = await client.ExecuteAsync(request);
            Console.WriteLine($"[{DateTime.Now.ToLongTimeString()}] {response.Content}");
            
        }
    }
}
