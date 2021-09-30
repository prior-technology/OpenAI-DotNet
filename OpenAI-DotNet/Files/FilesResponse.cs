using System.Text.Json.Serialization;

namespace OpenAI
{
    public class FilesResponse
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("object")]
        public string OpenAiObjectType { get; set; }

        [JsonPropertyName("bytes")]
        public int Bytes { get; set; }
        
        [JsonPropertyName("created_at")]
        public long CreatedAt { get; set; }
        
        [JsonPropertyName("filename")] 
        public string Filename { get; set; }
        
        [JsonPropertyName("purpose")] 
        public string Purpose { get; set; }
    }
}
