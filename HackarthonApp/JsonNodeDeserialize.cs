using System;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace HackarthonApp
{
    public class JsonNodeDeserialize
    {
        public static void ShowJsonInfo(string jsonString)
        {
            // Create a JsonNode DOM from a JSON string.
            JsonNode artworkNode = JsonNode.Parse(jsonString)!;

            // Write JSON from a JsonNode
            var options = new JsonSerializerOptions { WriteIndented = true };
            //Console.WriteLine(artworkNode!.ToJsonString(options));

            //JsonNode idNode = artworkNode!["Id"]!;
            Console.WriteLine($"Type={artworkNode.GetType()}");

            JsonNode data = artworkNode!["data"]!;
            Console.WriteLine($"Type={data.GetType()}");
            //Console.WriteLine($"JSON={data.ToJsonString()}");

            string id = (artworkNode["data"]!["id"]!).ToString();
            Console.WriteLine($"data.id={id}");

            string type = (artworkNode["data"]!["type"]!).ToString();
            Console.WriteLine($"data.type={type}");

            string att = (artworkNode["data"]!["attributes"]!).ToString();
            //Console.WriteLine($"data.attributes={att}");

            string date = (artworkNode["data"]!["attributes"]!["Date"]!).ToString();
            Console.WriteLine($"data.attributes={date}");

            JsonNode titles = (artworkNode["data"]!["attributes"]!["Title"]!);
            JsonNode firstTitle = titles[0]!;
            string title = firstTitle["Title"]!.ToString();
            Console.WriteLine($"data.attributes.title.title={title}");

            //int idInt = (int)artworkNode!["Id"]!;
            //Console.WriteLine($"Value={idInt}");
        }
    }
}
