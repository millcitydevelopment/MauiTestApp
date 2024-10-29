namespace MauiApp1;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
		Phidget22.Net.EnableServerDiscovery(Phidget22.ServerType.Device);
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} timeed";
		else
			CounterBtn.Text = $"Clicked {count} timesed";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}

