
namespace HackarthonApp
{
    class Program
    {
        static HttpClient client = new HttpClient();

        static async void GetArtworkAsync(string path)
        {
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                //JavaScriptSerializer JSserializer = new JavaScriptSerializer();

                //artwork = JSserializer.Deserialize<Artwork>(data);
                //Console.WriteLine("received object: " + artwork);
                //Console.WriteLine("received object: " + data);
                JsonNodeDeserialize.ShowJsonInfo(data);
            }
            Console.WriteLine("response code: " + response.StatusCode);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Success status!");
            }
        }

        static void Main(string[] args)
        {
            RunAsync().GetAwaiter().GetResult();
            Console.WriteLine("Hello World!");
        }

        private static string urlParameters = "6b62e11399cdc969ce8c7778a1d9ba9194f791a3b33dddd3f91dc8d2c91bb19cf7a1b63bcc8f23029c5751a03557263fb92489754e3a63650bfb0f8c4e72d12fa3716011732cfdb6c30462759d288bfdf6c6b7740c0e7f6d7bed492b710198317aceab6950426bf5a61f74b7aaafa2efd063bd473f6fd3a1bc79f35dc009e151";

        static async Task RunAsync()
        {
            client.BaseAddress = new Uri("https://apihackaton.zacheta.art.pl/api/v1/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + urlParameters);

            /*                new MediaTypeWithQualityHeaderValue("application/json"));
            */

            try
            {
                // Get the artwork
                GetArtworkAsync("https://apihackaton.zacheta.art.pl/api/v1/artworks/1");
                //Console.WriteLine("received artwork's id: " + artwork.Id);
                //ShowArtwork(artwork);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            /*HttpResponseMessage response = client.GetAsync(urlParameters).Result;
            if (response.IsSuccessStatusCode)
            {
                
            }*/
             
        }
    }
}
