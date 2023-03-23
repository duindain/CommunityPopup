namespace CommunityPopup;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private async void OnCounterClicked(object sender, EventArgs e)
	{
		MessageService.ShowProgressIndicator("Long running task");

		Task.Delay(1000);

		await Navigation.PushAsync(new Page1());

        MessageService.HideProgressIndicator();

    }

    private async void OnCounterClicked2(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Page1());

    }


}

