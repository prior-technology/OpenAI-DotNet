using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace OpenAI
{
    ///<summary>
    /// Represents a request to the <see cref="SearchEndpoint"/>.
    /// </summary>
    internal sealed class AnswersRequestWithFileId
    {
        [JsonPropertyName("model")]
        public string Model { get; set; }

        [JsonPropertyName("question")]
        public string Question { get; set; }

        [JsonPropertyName("examples")]
        public string[][] Examples { get; set; }

        [JsonPropertyName("examples_context")]
        public string ExamplesContext { get; set; }

        [JsonPropertyName("file")]
        public string FileId { get; set; }

        [JsonPropertyName("search_model")]
        public string SearchModel { get; set; }

        [JsonPropertyName("max_rerank")]
        public int MaxRerank { get; set; }
        [JsonPropertyName("max_tokens")]
        public int MaxTokens { get; set; }
        [JsonPropertyName("n")]
        public int N { get; set; }
        [JsonPropertyName("return_metadata")]
        public bool ReturnMetadata { get; set; }
        [JsonPropertyName("return_prompt")]
        public bool ReturnPrompt { get; set; }
        [JsonPropertyName("user")]
        public string User { get; set; }
    }
}
