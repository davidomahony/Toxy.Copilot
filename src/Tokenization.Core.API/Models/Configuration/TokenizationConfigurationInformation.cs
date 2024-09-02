using Tokenization.Core.Enums.Configuration;

namespace Tokenization.Core.API.Models.Configuration
{
  //  [BsonIgnoreExtraElements]
    public class TokenizationConfigurationInformation : BaseConfigurationObject
    {
        public int Identifier { get; set; }

        public EncryptionType EncryptionType { get; set; }

        public TokenMethodUsed TokenizationMethod { get; set; }

        public string? Key { get; set; }

        public string? Salt { get; set; }

        public string? PreWrapper { get; set; }

        public string? PostWrapper { get; set; }

        /// <summary>
        /// Identifier token should be unique
        /// </summary>
        public string? PadIdentifier { get; set; }

        public string? TokenDetectorRegex { get; set; }

        public string? TokenParsingRegex { get; set; }
    }
}
