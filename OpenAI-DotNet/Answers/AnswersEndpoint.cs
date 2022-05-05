using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace OpenAI
{
    /// <summary>
    /// The endpoint first searches over provided documents or file to find relevant context for the
    /// input question. Semantic search is used to rank documents by relevance to the question. The
    /// relevant context is combined with the provided examples and question to create the prompt for completion.
    /// 
    /// <see href="https://beta.openai.com/docs/guides/answers"/>
    /// </summary>
    public class AnswersEndpoint : BaseEndPoint
    {
        /// <inheritdoc />
        internal AnswersEndpoint(OpenAIClient api) : base(api) { }

        /// <inheritdoc />
        protected override string GetEndpoint(Engine engine = null)
        {
            return $"{Api.BaseUrl}answers";
        }

        /// <summary>
        /// Perform a semantic search over a list of documents
        /// </summary>
        /// <param name="searchRequest">The request containing the query and the documents to match against</param>
        /// <param name="engine">Optional, <see cref="Engine"/> to use when calling the API.
        /// Defaults to <see cref="OpenAIClient.DefaultEngine"/>.</param>
        /// <returns>Asynchronously returns a Dictionary mapping each document to the score for that document.
        /// The similarity score is a positive score that usually ranges from 0 to 300 (but can sometimes go higher),
        /// where a score above 200 usually means the document is semantically similar to the query.</returns>
        /// <exception cref="HttpRequestException">Raised when the HTTP request fails</exception>
        private async Task<AnswersResponse> GetAnswersResultsAsync(AnswersRequestWithFileId answersRequest)
        {
            var jsonContent = JsonSerializer.Serialize(answersRequest, Api.JsonSerializationOptions);
            var response = await Api.Client.PostAsync(GetEndpoint(), jsonContent.ToJsonStringContent());
            var resultAsString = await AttemptToReadContent(response);
            if (!response.IsSuccessStatusCode)
                throw new HttpRequestException(
                    $"{nameof(GetAnswersResultsAsync)} Failed!  HTTP status code: {response.StatusCode}. Request body: {jsonContent}. Response body {resultAsString}");
            
            var answersResponse = JsonSerializer.Deserialize<AnswersResponse>(resultAsString);

            if (answersResponse == null )
            {
                throw new HttpRequestException($"{nameof(GetAnswersResultsAsync)} returned no results!  HTTP status code: {response.StatusCode}. Response body: {resultAsString}");
            }

            answersResponse.SetResponseData(response.Headers);

            return answersResponse;
        }

        private async Task<string> AttemptToReadContent(HttpResponseMessage response)
        {
            try
            {
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception reading response content: {0}", e.ToString());
            }

            return "";
        }

        public async Task<string[]> GetAnswersAsync(string question, string fileId, string[][] examples, string examplesContext, string userId)
        {
 
            var request = new AnswersRequestWithFileId
            {
                Model = "davinci",
                Question = question,
                FileId = fileId,
                Examples = examples,
                ExamplesContext = examplesContext,
                MaxRerank = 50,
                MaxTokens = 60,
                N = 1,
                SearchModel = "ada",
                ReturnMetadata = true,
                ReturnPrompt = true,
                User = userId
            };
            request.Question = question;
            var response = await GetAnswersResultsAsync(request);

            return response.Answers;
        }
    }
}
