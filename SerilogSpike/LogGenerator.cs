using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SerilogSpike
{
    public class LogGenerator
    {
        public void Generate()
        {
            while (true)
            {
                Thread.Sleep(1000);
                MakeRequest("http://localhost:7818/api/throw/wcferror");
                MakeRequest("http://localhost:7818/api/throw/apierror");
                MakeRequest("http://localhost:7818/api/values");
            }
        }

        public void MakeRequest(string url)
        {
            Task.Run(() =>
            {
                HttpWebRequest webRequest = (HttpWebRequest) WebRequest.Create(url);
                webRequest.Method = "GET";
                //webRequest.Timeout = webRequest.ReadWriteTimeout = 10000;
                try
                {
                    HttpWebResponse webResponse = (HttpWebResponse) webRequest.GetResponse();
                    Console.WriteLine($"Completed: {url} ({webResponse.StatusCode})");
                }
                catch (System.Net.WebException ex)
                {
                    Console.WriteLine($"Web Exception: {url} ({ex.Message})");
                }
            });
        }
    }
}
