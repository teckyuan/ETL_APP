using HtmlAgilityPack;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace ETL_APP
{
    class Program
    {
        static IConfiguration config;

        static void Main(string[] args)
        {
            //load from config
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            //test
            Console.WriteLine($" Hello { config["url"] } !");

            //download webpage from url
            Task t = new Task(DownloadPageAsync);
            t.Start();
            Console.WriteLine("Downloading page...");
            Console.ReadLine();
        }

        static async void DownloadPageAsync()
        {
            var doc = new HtmlDocument();
            string url = config["url"];


            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(url))
            using (HttpContent content = response.Content)
            {
                string result = await content.ReadAsStringAsync();
                doc.LoadHtml(result);

                var MAGNUM = doc.DocumentNode
                .SelectNodes("/html/body/div[3]/div[3]/div[1]");

                var DAMACAI = doc.DocumentNode
                .SelectNodes("/html/body/div[3]/div[3]/div[2]");

                var TOTO = doc.DocumentNode
                .SelectNodes("/html/body/div[3]/div[3]/div[3]");

                //Console.WriteLine(result);
            }
        }
    }
}
