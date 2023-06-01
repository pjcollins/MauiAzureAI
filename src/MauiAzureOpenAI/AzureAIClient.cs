using Azure;
using Azure.AI.OpenAI;

namespace MauiAzureOpenAI
{
    public class AzureAIClient
    {
        const string DeploymentName = "vscx-sdk-gpt-35-turbo";

        OpenAIClient Client { get; set; }

        public AzureAIClient(string endpoint, string key)
        {
            Client = new OpenAIClient(new Uri(endpoint), new AzureKeyCredential(key));
        }

        public IReadOnlyList<Choice> GetCompletionResponses(CompletionsOptions options)
        {
            Response<Completions> completionResponses = Client.GetCompletions(DeploymentName, options);
            return completionResponses.Value.Choices;
        }

        public IReadOnlyList<ChatChoice> GetChatResponses(ChatCompletionsOptions options)
        {
            Response<ChatCompletions> chatResponse = Client.GetChatCompletions(DeploymentName, options);
            return chatResponse.Value.Choices;
        }

        public string GetDefaultCompletionResponse(string prompt)
        {
            var options = new CompletionsOptions()
            {
                Prompts =
                {
                    prompt,
                },
            };

            var responses = GetCompletionResponses(options);

            if (responses.Count > 0)
            {
                return responses[0].Text;
            }
            else
            {
                Console.Error.Write($"Failed to retrieve a completion response from: `{prompt}`");
                return string.Empty;
            }
        }

        public string GetDefaultChatResponse(string prompt)
        {
            var options = new ChatCompletionsOptions()
            {
                Messages =
                {
                    new ChatMessage(ChatRole.User, prompt),
                },
            };

            var responses = GetChatResponses(options);

            if (responses.Count > 0)
            {
                return responses[0].Message.Content;
            }
            else
            {
                Console.Error.Write($"Failed to retrieve a chat response from: `{prompt}`");
                return string.Empty;
            }
        }

    }
}
