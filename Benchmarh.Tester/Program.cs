using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace Benchmarh.Tester
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Console App Started.");

            do
            {
                Console.WriteLine("Please Choose Request Type. (Sync = 1, Async = 2)");
                int requestType = int.Parse(Console.ReadLine());

                Console.WriteLine("How Many Requests Do You Want to Send?");
                int requestCount = int.Parse(Console.ReadLine());

                var timer = new Stopwatch();

                timer.Start();
                var requests = requestType == 1 ? MakeSyncRequest(requestCount) : MakeAsyncRequest(requestCount);
                await Task.WhenAll(requests);
                timer.Stop();

                Console.WriteLine($"Process Finished. Total Time : {timer.ElapsedMilliseconds} MS");
                Console.WriteLine("If You Want To Do Another Process, Please Press r.");


            }
            while (Console.ReadKey().Key == ConsoleKey.R);
        }



        private static List<Task> MakeSyncRequest(int requestCount)
        {
            HttpClient client = new HttpClient() { BaseAddress = new Uri("https://localhost:5500/api/Benchmark/") };
            List<Task> requests = new List<Task>();


            for(int i = 0; i < requestCount; i++)
            {
                requests.Add(client.GetAsync("SyncOperation"));
            }

            return requests;
        }


        private static List<Task> MakeAsyncRequest(int requestCount)
        {
            HttpClient client = new HttpClient() { BaseAddress = new Uri("https://localhost:5500/api/Benchmark/") };
            List<Task> requests = new List<Task>();


            for (int i = 0; i < requestCount; i++)
            {
                requests.Add(client.GetAsync("AsyncOperation"));
            }

            return requests;
        }
    }
}
