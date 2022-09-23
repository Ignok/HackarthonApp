
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
            Console.WriteLine("Hello World!");
        }

        private static string url = "https://apihackaton.zacheta.art.pl/api/v1/";
        private static string urlParameters = "6b62e11399cdc969ce8c7778a1d9ba9194f791a3b33dddd3f91dc8d2c91bb19cf7a1b63bcc8f23029c5751a03557263fb92489754e3a63650bfb0f8c4e72d12fa3716011732cfdb6c30462759d288bfdf6c6b7740c0e7f6d7bed492b710198317aceab6950426bf5a61f74b7aaafa2efd063bd473f6fd3a1bc79f35dc009e151";
        private static string id = "7";
        private static string date = "2004";
        static async Task RunAsync()
        {
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + urlParameters);

            try
            {
                // Get the artwork with given id
                Console.WriteLine("Searching info about artwork id: " + id);
                string? data = await GetArtworkAsync(url + "artworks/" + id);
                if (data != null)
                {
                    JsonNodeDeserialize.ShowJsonInfo(data);
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Error: Artwork with given id doesn't exist");
                }
                //mając dostep do konkretnych atrybutów można już filtrować itd.


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
