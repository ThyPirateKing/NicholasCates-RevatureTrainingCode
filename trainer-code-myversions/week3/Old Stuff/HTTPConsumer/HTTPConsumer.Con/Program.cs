using System;
using System.Net.Http;
using System.Text.Json;
using HTTPConsumer.Models;

namespace HTTPConsumer.Con
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Http Client is starting...");

            string uri = "https://jsonplaceholder.typicode.com/posts";
            string baseurl = "http://localhost:5243/";

            HttpClient client = new HttpClient();

            string response = await client.GetStringAsync(baseurl + "Duck");

            List<Duck> duckList = JsonSerializer.Deserialize<List<Duck>>(response);

            foreach (var d in duckList)
                Console.WriteLine(d.color);
        }
    }
}