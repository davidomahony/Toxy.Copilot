namespace Tokenization.Core.API.Models.Configuration
{
    public class ServiceConfigurationInformation : BaseConfigurationObject
    {
        // Potentially need something here around authentication

        public string[]? AllowedInboundIps { get; set; }

        public string[]? AllowedOutboundIps { get; set; }
    }
}
