using System.Collections.Generic;
using System.Threading.Tasks;
using Tokenization.Core.API.Models.Configuration;
using Tokenization.Core.API.Repositories;

namespace Tokenization.Core.API.Services
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly IGenericRepository<TenantConfiguration> _repository;

        public ConfigurationService(IGenericRepository<TenantConfiguration> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TenantConfiguration>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<TenantConfiguration> GetByIdAsync(string id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<TenantConfiguration> InsertAsync(TenantConfiguration entity)
        {
            return await _repository.InsertAsync(entity);
        }

        public async Task<TenantConfiguration> UpdateAsync(TenantConfiguration entity)
        {
            return await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(string id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}

