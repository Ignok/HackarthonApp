using System;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace HackarthonApp
{
    public class JsonNodeDeserialize
    {
        public static void ShowJsonInfo(string jsonString)
        {
            // Create a JsonNode DOM from a JSON string
            JsonNode artworkNode = JsonNode.Parse(jsonString)!;

            // Write JSON from a JsonNode
            var options = new JsonSerializerOptions { WriteIndented = true };

            JsonNode data = artworkNode!["data"]!;

            string id = (artworkNode["data"]!["id"]!).ToString();
            Console.WriteLine($" -id={id}");

            string type = (artworkNode["data"]!["type"]!).ToString();
            Console.WriteLine($" -type={type}");

            string att = (artworkNode["data"]!["attributes"]!).ToString();

            string date = (artworkNode["data"]!["attributes"]!["Date"]!).ToString();
            Console.WriteLine($" -date={date}");

            string category = (artworkNode["data"]!["attributes"]!["Category"]!["Name"]!).ToString();
            Console.WriteLine($" -category={category}");

            JsonNode titles = (artworkNode["data"]!["attributes"]!["Title"]!);
            JsonNode firstTitle = titles[0]!;
            string title = firstTitle["Title"]!.ToString();
            Console.WriteLine($" -title={title}");
        }
    }
}
