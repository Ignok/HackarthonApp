using System;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace HackarthonApp
{
    public class JsonNodeDeserialize
    {
        public static void DeserializeZacheta(string jsonString)
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

            /* and future audiodescription:
            string date = (artworkNode["data"]!["attributes"]!["Audiodescription"]!).ToString();
            Console.WriteLine($" -audiodescription={audiodescription}");
            */

            //and so on...
        }

        public static void DeserializeEuropeana(string jsonString)
        {
            JsonNode artworkNode = JsonNode.Parse(jsonString)!;
            var options = new JsonSerializerOptions { WriteIndented = true };

            JsonNode items = (artworkNode["items"]!);
            JsonNode item = items[0]!;
            JsonNode countries = item["country"]!;
            string country = countries[0]!.ToString();
            Console.WriteLine($" -country={country}");

            JsonNode descriptions = item["dcDescription"]!;
            string dcDescription = descriptions[1]!.ToString();
            Console.WriteLine($" -description={dcDescription}");

            JsonNode titles = item["title"]!;
            string enTitle = titles[0]!.ToString();
            Console.WriteLine($" -en.title={enTitle}");
            string ogTitle = titles[1]!.ToString();
            Console.WriteLine($" -original.title={ogTitle}");

            JsonNode years = item["year"]!;
            string year = years[0]!.ToString();
            Console.WriteLine($" -year={year}");

            /* and future audiodescription:
            JsonNode audiodescriptions = item["audiodescription"]!;
            string audiodescription = audiodescriptions[0]!.ToString();
            Console.WriteLine($" -audiodescription={audiodescription}");
            */
        }
    }
}
