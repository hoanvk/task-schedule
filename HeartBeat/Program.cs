using Quartz.Logging;
using System;
using System.Net;

namespace HeartBeat
{
    public class Program
    {
        private static void Main(string[] args)
        {
            //Ssl.EnableTrustedHosts();
            ServicePointManager
                .ServerCertificateValidationCallback +=
                (sender, cert, chain, sslPolicyErrors) => true;
            LogProvider.SetCurrentLogProvider(new ConsoleLogProvider());
            TaskQueue task = new TaskQueue();
            task.RunTask().Wait();

            Console.WriteLine("Press any key to close the application");
            Console.ReadKey();
        }
        
    }
}
