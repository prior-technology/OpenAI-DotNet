using System.Text.Json.Serialization;

namespace OpenAI
{
    public class SearchDocument
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }
        [JsonPropertyName("metadata")]
        public string MetaData { get; set; }
    }
}
