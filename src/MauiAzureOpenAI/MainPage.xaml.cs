namespace MauiAzureOpenAI;

public partial class MainPage : ContentPage
{
    AzureAIClient client;

    public MainPage()
    {
        InitializeComponent();
        client = new AzureAIClient(SecretManager.GetAzureAIEndpoint(), SecretManager.GetAzureAIKey());
    }

    void OnEntryTextChanged(object sender, TextChangedEventArgs e)
    {
    }

    void OnEntryCompleted(object sender, EventArgs e)
    {
        var prompt = ((Entry)sender).Text;
        var chatText = client.GetDefaultChatResponse(prompt);
        UpdateLabel(chatText);
    }

    void UpdateLabel(string text)
    {
        Application.Current.MainPage.Dispatcher.Dispatch(() => responseLabel.Text += $"\n{text}\n");
    }

}

