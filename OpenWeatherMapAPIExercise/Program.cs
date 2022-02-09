using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net.Http;

namespace OpenWeatherMapAPIExercise
{
      class Program
    {
        static void Main(string[] args)
        {
          
            var client = new HttpClient();
            Console.WriteLine("Enter your API Key:");
            var apiKey = Console.ReadLine();
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Enter zip code: ");
                var zipCode = Console.ReadLine();
                var weatherURL = $"http://api.openweathermap.org/data/2.5/weather?zip={zipCode}&units=imperial&appid={apiKey}";

                var response = client.GetStringAsync(weatherURL).Result;
                var formattedResponse = JObject.Parse(response).GetValue("main").ToString();
                Console.WriteLine(formattedResponse);
                Console.WriteLine();
                Console.WriteLine("would you like to  choose a different zip code ?");
                var userInput = Console.ReadLine();
                Console.WriteLine();
                if(userInput.ToLower() == "no")
                {
                    break;
                }
            }

        }
    }
}
