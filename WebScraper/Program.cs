using System;
using System.IO;
using System.Net;
using System.Net.Http;

namespace WebScraper
{
    class Program
    {
        static void Main(string[] args)
        {
            ///*
            string url = "http://diseasesdatabase.com";
            
            using (WebClient client = new WebClient())
            {
                string html = client.DownloadString(url);
                Console.WriteLine(html);
            }
            //*/
            /*
            WebRequest req = HttpWebRequest.Create(url);
            req.Method = "GET";

            string source;
            using (StreamReader reader = new StreamReader(req.GetResponse().GetResponseStream()))
            {
                source = reader.ReadToEnd();
            }

            Console.WriteLine(source);
            */
        }
    }
}
