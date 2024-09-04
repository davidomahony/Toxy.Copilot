using Tokenization.Core.API.Models.Configuration;
using MongoDB.Driver;

namespace Tokenization.Core.API.Repositories
{
    public class ConfigurationRepository : IGenericRepository<TenantConfiguration>
    {
        private readonly IMongoCollection<TenantConfiguration> _collection;

        public ConfigurationRepository(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("MongoDb");
            var databaseName = configuration.GetSection("MongoDbSettings:DatabaseName").Value;

            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);

            _collection = database.GetCollection<TenantConfiguration>("TenantConfigurations");
        }

        public async Task<IEnumerable<TenantConfiguration>> GetAllAsync()
            =>  await _collection.Find(_ => true).ToListAsync();

        public async Task<TenantConfiguration> GetByIdAsync(object id)
            => await _collection.Find(Builders<TenantConfiguration>.Filter.Eq("_id", id)).FirstOrDefaultAsync();
        

        public async Task<TenantConfiguration> InsertAsync(TenantConfiguration entity)
        {
            await _collection.InsertOneAsync(entity);
            return entity;
        }

        public async Task<TenantConfiguration> UpdateAsync(TenantConfiguration entity)
        {
            var idProperty = entity.GetType().GetProperty("Id") ?? throw new InvalidOperationException("Entity does not have an Id property.");
            
            var id = (idProperty.GetValue(entity)?.ToString()) ?? throw new InvalidOperationException("Id property value is null.");
            
            await _collection.ReplaceOneAsync(Builders<TenantConfiguration>.Filter.Eq("_id", id), entity);
            
            return entity;
        }

        public async Task DeleteAsync(object id)
            => await _collection.DeleteOneAsync(Builders<TenantConfiguration>.Filter.Eq("_id", id));       
    }
}
