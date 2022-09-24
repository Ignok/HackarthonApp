
namespace HackarthonApp
{
    class Program
    {
        static HttpClient client = new HttpClient();

        static async Task<string?> GetArtworkAsync(string path)
        {
            HttpResponseMessage response = await client.GetAsync(path);
            Console.WriteLine("Response code: " + response.StatusCode);
            string data;
            if (response.IsSuccessStatusCode)
            {
                data = await response.Content.ReadAsStringAsync();
                return data;
            }
            return null;
        }

        static void Main(string[] args)
        {
            RunAsync().GetAwaiter().GetResult();
        }

        private static string urlZacheta = "https://apihackaton.zacheta.art.pl/api/v1/";
        private static string urlEuropeana = "https://api.europeana.eu/record/v2/search.json";

        private static string zachetaKey = "6b62e11399cdc969ce8c7778a1d9ba9194f791a3b33dddd3f91dc8d2c91bb19cf7a1b63bcc8f23029c5751a03557263fb92489754e3a63650bfb0f8c4e72d12fa3716011732cfdb6c30462759d288bfdf6c6b7740c0e7f6d7bed492b710198317aceab6950426bf5a61f74b7aaafa2efd063bd473f6fd3a1bc79f35dc009e151";
        private static string europeanaKey = "dleciscelans";

        private static string id = "7";
        private static string searchedTitle = "\"Osvald%20Helmuth%20dressed%20as%20Mona%20Lisa\"";

        static async Task RunAsync()
        {
            client.BaseAddress = new Uri(urlZacheta);
            client.DefaultRequestHeaders.Accept.Clear();

            //Connect to Zacheta API
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + zachetaKey);
            try
            {
                // Get the artwork with given id
                Console.WriteLine("Searching info about artwork id: " + id + " in Zacheta...");
                string? data = await GetArtworkAsync(urlZacheta + "artworks/" + id);
                if (data != null)
                {
                    Console.WriteLine("Fetched data:");
                    JsonNodeDeserialize.DeserializeZacheta(data);
                }
                else
                {
                    Console.WriteLine("Error: Artwork with given id doesn't exist");
                }
                //with access to specific attributes we can easily filter and search for desired artworks
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine();

            client.DefaultRequestHeaders.Clear();
            //Connect to Europeana API
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + zachetaKey);
            try
            {
                //Get information about artwork with given string in the title
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + europeanaKey);
                Console.WriteLine("Searching for an art piece called: \"Osvald Helmuth dressed as Mona Lisa\" in Europeana...");
                string? data = await GetArtworkAsync("https://api.europeana.eu/record/v2/search.json?wskey=" + europeanaKey + "&query=" + searchedTitle);
                if (data != null)
                {
                    Console.WriteLine("Fetched data:");
                    JsonNodeDeserialize.DeserializeEuropeana(data);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();

        }
    }
}
