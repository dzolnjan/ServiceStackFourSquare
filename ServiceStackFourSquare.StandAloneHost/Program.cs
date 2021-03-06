﻿using System;

namespace ServiceStackFourSquare.StandAloneHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var listeningOn = args.Length == 0 ? "http://*:1337/" : args[0];
            var appHost = new AppHost();
            appHost.Init();
            appHost.Start(listeningOn);

            Console.WriteLine("AppHost Created at {0}, listening on {1}", DateTime.Now, listeningOn);
            Console.WriteLine("Open browser and go to http://localhost:1337/categories");
            Console.ReadKey();
        }
    }
}
