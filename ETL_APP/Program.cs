using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace ETL_APP
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            //test
            Console.WriteLine("Hello World!");
        }
    }
}
