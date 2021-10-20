using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ClientREST
{
    public enum httpVerb
    { 
        GET,
        POST
    }
    public class RestClient
    {
        public string endPoint { get; set; }
        public httpVerb httpMethod { get; set; }
        public RestClient()
        {
            endPoint = string.Empty;
            httpMethod = httpVerb.GET;
        }

        public string makeRequest()
        {
            string response = string.Empty;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endPoint);
            request.Method = httpMethod.ToString();
            using (HttpWebResponse r = (HttpWebResponse)request.GetResponse())
            {
                if (r.StatusCode != HttpStatusCode.OK)
                {
                    throw new ApplicationException("Error");
                }

                /// process the response stream.. could be JSON, XML, HTML, etc
                using (Stream responseStream = r.GetResponseStream())
                {
                    if (r != null)
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            response = reader.ReadToEnd();
                        }
                        // end of stream
                    }
                }// end of response stream
            }// end of response
            return response;
        }
    }
}
