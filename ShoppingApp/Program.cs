using Microsoft.Owin.Hosting;
using Serilog;
using System;
using System.Net.Http;

namespace ShoppingApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.ColoredConsole()
                .CreateLogger();
                

            string baseAddress = "http://localhost:52559/";

            // Start OWIN host 
            using (WebApp.Start<Startup>(url: baseAddress))
            {
                // Create HttpCient and make a request to api/values 
                HttpClient client = new HttpClient();


                Console.WriteLine($"Server is running on {baseAddress}");
                Console.WriteLine("Press <enter> to stop server");
                Console.ReadLine();
            }
        }
    }
}