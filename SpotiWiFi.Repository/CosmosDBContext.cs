using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiWiFi.Repository
{
    public class CosmosDBContext
    {
        private CosmosClient client {  get; set; }
        private string AccountEndpoint { get; set; }
        private string TokenCredential { get; set; }
        private string DatabaseName = "spotiwifi";
        private string ContainerName {  get; set; }

        private Database Database { get; set; }
        private Container Container { get; set; }


        public CosmosDBContext(IConfiguration configuration)
        {
            this.AccountEndpoint = configuration["CosmosConnection:AccountEndpoint"]?.ToString();
            this.TokenCredential = configuration["CosmosConnection:TokenCredential"]?.ToString();
            this.client = new CosmosClient(AccountEndpoint, TokenCredential);
            this.Database = this.client.GetDatabase(this.DatabaseName);
        }

        public void SetContainer(string containerName)
        {
            this.ContainerName = containerName;
            this.Container = Database.GetContainer(this.ContainerName);
        }

        public async Task SaveOrUpdate<T>(T entity, string partitionKey) where T : class
        {
            await Container.UpsertItemAsync<T>(item: entity, partitionKey: new PartitionKey(partitionKey));
        }

        public async Task Delete<T>(string id, string partitionKey) where T : class
        {
            await Container.DeleteItemAsync<T>(id, new PartitionKey(partitionKey));
        }

        public async Task<List<T>> ReadAll<T>() where T : class
        {
            var query = new QueryDefinition(
                    query : "SELECT * FROM " + this.ContainerName
            );
            using FeedIterator<T> feedIterator = Container.GetItemQueryIterator<T>(query) as FeedIterator<T>;

            List<T> result = new List<T>();

            while (feedIterator.HasMoreResults)
            {
                FeedResponse<T> response = await feedIterator.ReadNextAsync();

                foreach (var item in response)
                {
                    result.Add(item);
                }
            }
            return result;

        }

        public async Task<T> ReadItem<T>(string id)
        {
            var query = new QueryDefinition(
                query: "SELECT * FROM " + this.ContainerName + " c WHERE c.id = @id"
            ).WithParameter("@id", id);

            using FeedIterator<T> feedIterator = Container.GetItemQueryIterator<T>(query) as FeedIterator<T>;

            List<T> result = new List<T>();

            while (feedIterator.HasMoreResults)
            {
                FeedResponse<T> response = await feedIterator.ReadNextAsync();

                foreach (var item in response)
                {
                    result.Add(item);
                }
            }
            return result.FirstOrDefault();
        }
    }
}
