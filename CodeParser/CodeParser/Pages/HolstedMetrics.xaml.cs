using CodeParser.Holsted;

namespace CodeParser.Pages;

[QueryProperty("Text","Text")]
public partial class HolstedMetrics : ContentPage
{
	public HolstedMetrics()
	{
		InitializeComponent();

		var holstedParser = new HolstedParser();
		var data = holstedParser.ParseCode(Text);
	}

	string text;
	public string Text { get; set; }
}