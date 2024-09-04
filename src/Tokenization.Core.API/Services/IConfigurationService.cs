using Tokenization.Core.API.Models.Configuration;

namespace Tokenization.Core.API.Services
{
    public interface IConfigurationService
    {
        Task<IEnumerable<TenantConfiguration>> GetAllAsync();
        Task<TenantConfiguration> GetByIdAsync(string id);
        Task<TenantConfiguration> InsertAsync(TenantConfiguration entity);
        Task<TenantConfiguration> UpdateAsync(TenantConfiguration entity);
        Task DeleteAsync(string id);
    }
}
