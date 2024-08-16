using System.IO.Ports;

namespace MauiApp1;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		double temp = ServiceLocator.Phidget.GetTemp1();

		string portId = string.Empty;
		string[] ports = SerialPort.GetPortNames();
		if (ports.Length > 0)
		{
			portId = ports.Where(x => x.IndexOf("usbserial") > -1).FirstOrDefault() ?? string.Empty;
			if (System.Diagnostics.Debugger.IsAttached)
			{
				System.Diagnostics.Debug.WriteLine(ports[0]);
			}
		}


		CounterBtn.Text = $"Temperature: {temp}   Serial: {portId}";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}

