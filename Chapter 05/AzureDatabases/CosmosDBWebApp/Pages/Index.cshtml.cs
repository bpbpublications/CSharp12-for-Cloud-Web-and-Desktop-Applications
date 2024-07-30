using CosmosDBWebApp.Helper;
using CosmosDBWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Azure.Cosmos;

namespace CosmosDBWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly CosmosClient cosmosClient;
        private readonly string databaseName = "ThiagoCosmosDB";
        private readonly string sourceContainerName = "ThiagoContainer";

        public IndexModel(ILogger<IndexModel> logger, CosmosClient cosmosClient)
        {
            this._logger = logger;
            this.cosmosClient = cosmosClient;
        }

        public async Task OnGet()
        {
            DatabaseResponse databaseResponse = await cosmosClient.CreateDatabaseIfNotExistsAsync(databaseName);
            Database database = databaseResponse.Database;

            ContainerResponse container = await database.CreateContainerIfNotExistsAsync(new ContainerProperties(sourceContainerName, "/id"));            

            await CreateItemsAsync(cosmosClient, database.Id, container.Container.Id);
        }
        private static async Task CreateItemsAsync(CosmosClient cosmosClient, string databaseId, string containerId)
        {
            Container sampleContainer = cosmosClient.GetContainer(databaseId, containerId);

            for (int i = 0; i < 15; i++)
            {
                var person = CreatePerson.GetNewPerson();
                await sampleContainer.CreateItemAsync<Person>(person,
                    new PartitionKey(person.Id));
            }
        }
    }
}