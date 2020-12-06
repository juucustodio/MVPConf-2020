using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using MVPConf.Backend.Domain;
using MVPConf.Backend.Repository.Contract;
using MVPConf.Backend.Extensions;
using System.Linq;
using Microsoft.Extensions.Options;
using MVPConf.Backend.Config;

namespace MVPConf.Backend.Repository
{
    public class SpeakerRepository : ISpeakerRepository
    {
        private CloudStorageAccount _storageAccount;
        private CloudTableClient _tableClient;

        public SpeakerRepository(IOptions<CommonConfigurations> options)
        {
            _storageAccount = CloudStorageAccount.Parse(options.Value.StorageAccountConnectionString);
        }

        public async Task<Speaker> GetSpeakerById(int id)
        {
            var table = await GetTable();

            var queryCondition = TableQuery.GenerateFilterCondition("RowKey", QueryComparisons.Equal, id.ToString());

            var query = new TableQuery<Speaker>().Where(queryCondition);

            var data = await table.ExecuteQuerySegmentedAsync(query, new TableContinuationToken());

            return data?.Results.FirstOrDefault();
        }

        public async Task<List<Speaker>> GetSpeakers()
        {
            var table = await GetTable();

            var query = new TableQuery<Speaker>();

            var data = await table.ExecuteQuerySegmentedAsync(query, new TableContinuationToken());

            return data?.Results;
        }

        public async Task Save(Speaker speaker)
        {
            var table = await GetTable();

            TableOperation insertOperation = TableOperation.Insert(speaker);

            await table.ExecuteAsync(insertOperation);
        }

        public async Task Save(List<Speaker> speakers)
        {
            var speakersBatches = speakers.Batch(100);

            var table = await GetTable();

            foreach (var batch in speakersBatches)
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

            CloudTable table = _tableClient.GetTableReference(nameof(Speaker));

            await table.CreateIfNotExistsAsync();

            return table;
        }
    }
}
