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
            string baseAddress = "http://localhost:52559/";

            // Start OWIN host 
            using (WebApp.Start<Startup>(url: baseAddress))
            {
                Console.WriteLine($"Server is running on {baseAddress}");
                Console.WriteLine("Press <enter> to stop server");
                Console.ReadLine();
            }
        }
    }
}