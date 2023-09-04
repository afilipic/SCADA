using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RTU
{
    class Program
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private static readonly Random random = new Random();

        static async Task Main(string[] args)
        {

            var timer = new System.Threading.Timer(
                async _ =>
                {
                    var aiIds = await GetAllAIIdsAsync();
                    var diIds = await GetAllDIIdsAsync();
                    string path;
                    int aiOrDi = random.Next(1, 3);

                    if (aiOrDi == 1)
                    {
                        int value = (int)ReturnValueDI();
                        int randomIndex = random.Next(diIds.Count);
                        string id = diIds[randomIndex];

                        path = $"http://localhost:5001/tags/DI/{id}/{value}";
                    }
                    else
                    {
                        int value = (int)ReturnValue();
                        int randomIndex = random.Next(aiIds.Count);
                        string id = aiIds[randomIndex];

                        path = $"http://localhost:5001/tags/AI/{id}/{value}";
                    }

                    var emptyContent = new StringContent("{}", Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync(path, emptyContent);

                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"Data sent successfully on: {path}");
                    }
                    else
                    {
                        Console.WriteLine($"Failed to send data on: {path}. Status code: {response.StatusCode}");
                    }
                },
                null,
                TimeSpan.Zero,
                TimeSpan.FromSeconds(5));

            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();

            timer.Dispose();
        }

        public static double ReturnValue()
        {
            int choice = random.Next(1, 4);
            return choice switch
            {
                1 => Sine(),
                2 => Cosine(),
                3 => Ramp(),
                _ => 1000,
            };
        }

        private static double Sine()
        {
            return 100 * Math.Sin((double)DateTime.Now.Second / 60 * 2 * Math.PI); // Adjusted to a complete sine wave over a minute
        }

        private static double Cosine()
        {
            return 100 * Math.Cos((double)DateTime.Now.Second / 60 * 2 * Math.PI); // Adjusted to a complete cosine wave over a minute
        }

        private static double Ramp()
        {
            return 100 * DateTime.Now.Second / 60.0; // Added .0 for clarity
        }

        public static double ReturnValueDI()
        {
            int choice = random.Next(1, 4);
            return choice switch
            {
                1 => SineDI(),
                2 => CosineDI(),
                3 => RampDI(),
                _ => 1000,
            };
        }

        private static double SineDI()
        {
            double value = Math.Sin((double)(DateTime.Now.Minute % 60) / 60 * 2 * Math.PI);
            return (value + 1) / 2;  // Map range from [-1, 1] to [0, 1]
        }

        private static double CosineDI()
        {
            double value = Math.Cos((double)(DateTime.Now.Minute % 60) / 60 * 2 * Math.PI);
            return (value + 1) / 2;  // Map range from [-1, 1] to [0, 1]
        }

        private static double RampDI()
        {
            return (DateTime.Now.Minute % 60) / 60.0;
        }



        public static async Task<List<string>> GetAllAIIdsAsync()
        {
            var response = await httpClient.GetAsync("http://localhost:5001/tags/AI/ids");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrWhiteSpace(content) || content == "[]")  // Check if the content is empty or just an empty array
                {
                    Console.WriteLine("No AI Ids found.");
                    return new List<string>();  // Return an empty list
                }

                var ids = JsonConvert.DeserializeObject<List<string>>(content);
                return ids;
            }
            else
            {
                throw new Exception($"Failed to fetch AI Ids. Status code: {response.StatusCode}");
            }
        }


        public static async Task<List<string>> GetAllDIIdsAsync()
        {
            var response = await httpClient.GetAsync("http://localhost:5001/tags/DI/ids");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrWhiteSpace(content) || content == "[]")  // Check if the content is empty or just an empty array
                {
                    Console.WriteLine("No DI Ids found.");
                    return new List<string>();  // Return an empty list
                }

                var ids = JsonConvert.DeserializeObject<List<string>>(content);
                return ids;
            }
            else
            {
                throw new Exception($"Failed to fetch DI Ids. Status code: {response.StatusCode}");
            }
        }


    }

}
