using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace OpenAI
{
    public class FilesEndpoint : BaseEndPoint
    {
        public FilesEndpoint(OpenAIClient api) : base(api)
        {
        }

        protected override string GetEndpoint(Engine engine = null)
        {
            return $"{Api.BaseUrl}files";
        }


        /// <summary>
        /// Uploads a file, which contains list of documents which can be used for searching, question-answering, classification or fine-tuning.
        /// </summary>
        /// <returns>Asynchronously returns <see cref="FilesResponse"/> with id of the uploaded file</returns>
        /// <exception cref="HttpRequestException">Raised when the HTTP request fails</exception>
        public async Task<FilesResponse> UploadFileAsync(UploadFileRequest request)
        {
            /* should be equivalent of
             curl https://api.openai.com/v1/files \
                -H "Authorization: Bearer YOUR_API_KEY" \
                -F purpose="answers" \
                -F file='@puppy.jsonl' 
            */
            var content = new MultipartFormDataContent();
            content.Add(new StringContent(request.Purpose), "purpose");
            content.Add(request.Content, "file", request.FileName);

            var response = await Api.Client.PostAsync(GetEndpoint(), content);
            var resultAsString = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonSerializer.Deserialize<FilesResponse>(resultAsString);
            }

            throw new HttpRequestException($"{nameof(UploadFileAsync)} Failed! HTTP status code: {response.StatusCode}.");
        }
    }
}
