using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace OpenAI
{
    ///<summary>
    /// Represents a request to the <see cref="SearchEndpoint"/>.
    /// </summary>
    internal sealed class AnswersRequestWithDocuments
    {

        [JsonPropertyName("model")]
        public string Model { get; }

        [JsonPropertyName("question")]
        public string Question { get; }

        [JsonPropertyName("examples")]
        public string[][] Examples { get; }

        [JsonPropertyName("examples_context")]
        public string ExamplesContext { get; }

        [JsonPropertyName("documents")]
        public string[] Documents { get; }

        [JsonPropertyName("search_model")]
        public string SearchModel { get; }

        [JsonPropertyName("max_rerank")]
        public int MaxRerank { get; }

        [JsonPropertyName("n")]
        public int N { get; }

    }
}
