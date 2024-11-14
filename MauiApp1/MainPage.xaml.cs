//using Phidget22;

namespace MauiApp1;

public partial class MainPage : ContentPage
{
	int count = 0;

//	TemperatureSensor temp;

	public MainPage()
	{
		InitializeComponent();
//		temp = new TemperatureSensor();
//		temp.IsLocal = true;
//		temp.Channel = 0;
//		temp.Open();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;
		string btnText = count + "   Binding Code Temp: " + ServiceLocator.Phidget.GetTemp1();
//		btnText += "   Phidget NuGet Temp: " +  temp.Temperature;
		CounterBtn.Text = btnText;
	}
}

