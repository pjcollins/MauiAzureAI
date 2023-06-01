namespace MauiAzureOpenAI
{
    public static class SecretManager
    {
        const string AzureAIEndpointVariableName                = "AZURE_AI_ENDPOINT";
        const string AzureAIEndpointFileVariableName            = "AZURE_AI_ENDPOINT_FILE";
        const string AzureAIKeyVariableName                     = "AZURE_AI_KEY";
        const string AzureAIKeyFileVariableName                 = "AZURE_AI_KEY_FILE";


        // TODO add crossplat filesystem support

        public static string GetAzureAIEndpoint()
        {
            var epVarValue = Environment.GetEnvironmentVariable(AzureAIEndpointVariableName);
            if (!string.IsNullOrEmpty(epVarValue))
                return epVarValue;

            var epFileVarValue = Environment.GetEnvironmentVariable(AzureAIEndpointFileVariableName);
            if (File.Exists(epFileVarValue))
                return File.ReadAllText(epFileVarValue);

            return string.Empty;
        }

        public static string GetAzureAIKey()
        {
            var keyVarValue = Environment.GetEnvironmentVariable(AzureAIKeyVariableName);
            if (!string.IsNullOrEmpty(keyVarValue))
                return keyVarValue;

            var keyFileVarValue = Environment.GetEnvironmentVariable(AzureAIKeyFileVariableName);
            if (File.Exists(keyFileVarValue))
                return File.ReadAllText(keyFileVarValue);

            return string.Empty;
        }

    }
}
