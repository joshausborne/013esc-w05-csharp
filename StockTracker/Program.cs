using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

class Program
{
    private static readonly HttpClient client = new HttpClient();

    static async Task Main()
    {
        string apiKey = "41K8F34VNSVLMK5S"; // free from Alpha Vantage

        // Creating and initializing a dictionary with stock symbols and cost basis
        Dictionary<string, double> stockCostBasis = new Dictionary<string, double>
        {
            { "AAPL", 164.24 },
            { "PTON", 35.60 },
            { "TSLA", 129.78 }
        };

        // Loop through the dictionary and compare current prices with cost basis
        Console.WriteLine("Stock comparison between current prices and cost basis:");

        foreach (KeyValuePair<string, double> entry in stockCostBasis)
        {
            string stockSymbol = entry.Key;
            string url = $"https://www.alphavantage.co/query?function=GLOBAL_QUOTE&symbol={stockSymbol}&apikey={apiKey}";
            double costBasis = entry.Value;

            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                JObject json = JObject.Parse(responseBody);
                string price = json["Global Quote"]["05. price"].ToString();
                double fetchedCurrentPrice = double.Parse(price);
                double calculate = fetchedCurrentPrice / costBasis;
                double result = Math.Abs(calculate - 1) * 100;

                Console.WriteLine();
                Console.WriteLine($"{stockSymbol} stock last closed at ${price}.");
                Console.WriteLine($"Your cost basis per share is ${costBasis:F2}.");

                string exclaim;
                string updown;

                if (calculate < 1)
                {
                    exclaim = "Bummer!";
                    updown = "down";
                }
                else
                {
                    exclaim = "Huzzah!";
                    updown = "up";
                }

                Console.WriteLine($"{exclaim} Your {stockSymbol} stock is {updown} {result:F2}%.");
                Console.WriteLine();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }
    }
}

