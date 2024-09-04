using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tokenization.Core.API.Models.Configuration;
using Tokenization.Core.API.Models.Configuration;

namespace Tokenization.Core.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConfigurationController
    {
        private readonly IConfigurationService _configurationService;

        public ConfigurationController(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TenantConfiguration>>> GetAll()
        {
            var configurations = await _configurationService.GetAllAsync();
            return Ok(configurations);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TenantConfiguration>> GetById(string id)
        {
            var configuration = await _configurationService.GetByIdAsync(id);
            if (configuration == null)
            {
                return NotFound();
            }
            return Ok(configuration);
        }

        [HttpPost]
        public async Task<ActionResult<TenantConfiguration>> Create(TenantConfiguration configuration)
        {
            var createdConfiguration = await _configurationService.InsertAsync(configuration);
            return CreatedAtAction(nameof(GetById), new { id = createdConfiguration.Id }, createdConfiguration);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TenantConfiguration>> Update(string id, TenantConfiguration configuration)
        {
            if (id != configuration.Id)
            {
                return BadRequest();
            }

            var updatedConfiguration = await _configurationService.UpdateAsync(configuration);
            if (updatedConfiguration == null)
            {
                return NotFound();
            }

            return Ok(updatedConfiguration);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var configuration = await _configurationService.GetByIdAsync(id);
            if (configuration == null)
            {
                return NotFound();
            }

            await _configurationService.DeleteAsync(id);
            return NoContent();
        }
    }
}
