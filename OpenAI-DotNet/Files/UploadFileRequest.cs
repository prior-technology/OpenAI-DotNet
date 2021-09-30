using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace OpenAI
{
    public class UploadFileRequest
    {
        private static string MapPurpose(FilePurpose purpose)
        {
            switch (purpose)
            {
                case FilePurpose.Search:
                    return "search";
                case FilePurpose.Answers:
                    return "answers";
                case FilePurpose.Classification:
                    return "classification";
                case FilePurpose.FineTune:
                    return "fine-tune";
            }

            throw new InvalidEnumArgumentException("purpose", (int)purpose, typeof(FilePurpose));
        }

        private HttpContent AsLines(IEnumerable<SearchDocument> documents)
        {
            var sb = new StringBuilder();
            var opts = new JsonSerializerOptions {IgnoreNullValues = true};
            foreach (var searchDocument in documents)
            {
                sb.AppendLine(JsonSerializer.Serialize(searchDocument, opts));
            }

            return new StringContent(sb.ToString());
        }
        public UploadFileRequest(string name, FilePurpose purpose, IEnumerable<SearchDocument> documents)
        {
            FileName = name;
            Purpose = MapPurpose(purpose);
            Content = AsLines(documents);
        }
        public string FileName { get; set; }
        public string Purpose { get; set; }
        /// <summary>
        /// JSONL file containing documents whose format depends on the purpose of the file
        /// </summary>
        public HttpContent Content { get; set; }
    }
}
