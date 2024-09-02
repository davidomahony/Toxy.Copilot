using MongoDB.Bson;

namespace Tokenization.Core.API.Models.Configuration
{
    public class TenantConfiguration : BaseConfigurationObject
    {
       // [BsonId]
        public ObjectId Id { get; set; }

        public IEnumerable<ServiceConfigurationInformation>? ServiceConfigurationInformation { get; set; }

        public IEnumerable<TokenizationConfigurationInformation>? TokenizationInformation { get; set; }
    }
}
