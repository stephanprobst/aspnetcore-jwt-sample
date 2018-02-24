﻿using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace SecuredWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseUrls("http://+:5001")
                .Build();
    }
}
