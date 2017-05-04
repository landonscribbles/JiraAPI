using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace JiraAPITesting {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Test line");
            HTTPTest();
        }

        public static void HTTPTest() {
            Console.WriteLine("Making Request");
            WebRequest request = WebRequest.Create("http://localhost:8080/rest/api/2/search?jql=assignee=");

            string auth = "";

            byte[] authBytes = Encoding.UTF8.GetBytes(auth);
            string b64Auth = System.Convert.ToBase64String(authBytes);

            request.Headers.Add("Authorization", "Basic " + b64Auth);

            WebResponse resp = request.GetResponse();

            Console.WriteLine(((HttpWebResponse)resp).StatusDescription);

            Stream dataStream = resp.GetResponseStream();

            StreamReader reader = new StreamReader(dataStream);

            string serverResp = reader.ReadToEnd();

            Console.WriteLine(serverResp);

            reader.Close();

            resp.Close();
        }
    }
}
