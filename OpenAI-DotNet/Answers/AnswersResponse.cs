using System.Collections.Generic;
using System.Text.Json.Serialization;
using OpenAI.Answers;

namespace OpenAI
{
    /// <summary>
    /// Represents a response from the <see cref="SearchEndpoint"/>.
    /// </summary>
    internal sealed class AnswersResponse : BaseResponse
    {
        /// <summary>
        /// The list of results
        /// </summary>
        [JsonPropertyName("answers")]
        public string[] Answers { get; set; }

        public string Completion { get; set; }
        public string File { get; set; }
        public string Model{ get; set; }
        public string Object{ get; set; }
        public string SearchModel { get; set; }
        public List<SelectedDocument> SelectedDocuments { get; set; }
    }
}
