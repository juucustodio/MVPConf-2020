using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using MVPConf.Backend.Domain;
using MVPConf.Backend.Repository.Contract;
using System.Linq;
using Microsoft.Extensions.Options;
using MVPConf.Backend.Extensions;
using MVPConf.Backend.Config;
using System.Collections.Generic;

namespace MVPConf.Backend.Repository
{
    public class TalkRepository : ITalkRepository
    {
        private CloudStorageAccount _storageAccount;
        private CloudTableClient _tableClient;

        public TalkRepository(IOptions<CommonConfigurations> options)
        {
            _storageAccount = CloudStorageAccount.Parse(options.Value.StorageAccountConnectionString);
        }

        public async Task<Talk> GetTalkById(int id)
        {
            var table = await GetTable();

            var queryCondition = TableQuery.GenerateFilterCondition("RowKey", QueryComparisons.Equal, id.ToString());

            var query = new TableQuery<Talk>().Where(queryCondition);

            var data = await table.ExecuteQuerySegmentedAsync(query, new TableContinuationToken());

            return data?.Results.FirstOrDefault();  
        }

        public async Task<List<Talk>> GetTalks()
        {
            var table = await GetTable();

            var query = new TableQuery<Talk>();

            var data = await table.ExecuteQuerySegmentedAsync(query, new TableContinuationToken());

            return data?.Results;
        }

        public async Task Save(Talk talk)
        {
            var table = await GetTable();

            TableOperation insertOperation = TableOperation.Insert(talk);

            await table.ExecuteAsync(insertOperation);
        }

        public async Task Save(List<Talk> talks)
        {
            var talksBatches = talks.Batch(100);

            var table = await GetTable();

            foreach (var batch in talksBatches)
            {
                var operationBatch = new TableBatchOperation();

                foreach (var item in batch)
                    operationBatch.InsertOrReplace(item);


                await table.ExecuteBatchAsync(operationBatch);
            }
        }

        private async Task<CloudTable> GetTable()
        {
            if (_tableClient == null)
                _tableClient = _storageAccount.CreateCloudTableClient();

            CloudTable table = _tableClient.GetTableReference(nameof(Talk   ));

            await table.CreateIfNotExistsAsync();

            return table;
        }
    }
}
