using Microsoft.Azure.Cosmos;

namespace cosmosdbpractice
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateItem().Wait();
        }

        private static async Task CreateItem()
        {
            // blank for security purposes
            var cosmosUrl = "";
            var cosmoskey = "";
            var databaseName = "";

            CosmosClient client = new CosmosClient(cosmosUrl, cosmoskey);
            Database database = await client.CreateDatabaseIfNotExistsAsync(databaseName);
            Container container = await database.CreateContainerIfNotExistsAsync(
                "NBAPlayers", "/playername", 400);

            dynamic testItem = new { id = Guid.NewGuid().ToString(), playerName = "LeBron James", details = "Lakers" };
            ItemResponse<dynamic> response = await container.CreateItemAsync(testItem);
        }
    }
}

