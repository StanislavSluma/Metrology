using CodeParser.Chepin;
using System.Collections.ObjectModel;

namespace CodeParser.Pages;

[QueryProperty("Text","Text")]
public partial class ChepinMetrics : ContentPage
{
	ChepinParser parser;
	public ObservableCollection<ChepinInfo> ChepinMetricsInfo { get; set; } = new();
	public ObservableCollection<SpenInfo> SpenInfos { get; set; } = new();
	public ChepinMetrics()
	{
		BindingContext = this;
		InitializeComponent();
		parser = new();
	}

	string text;
	public string Text { get { return text; } set {  text = value; OnPropertyChanged("Text"); } }
    private void ContentPage_Loaded(object sender, EventArgs e)
    {
		var data = parser.CalculateSpan(Text);
		var summarySpen = 0;
		foreach(var item in data)
		{
			SpenInfos.Add(new SpenInfo(item.Key, item.Value - 1));
			summarySpen += item.Value - 1;
		}
		SpenInfos.Add(new SpenInfo("Суммарный спен", summarySpen));

		var chepinMetricsData = parser.ParseCode(Text);
		foreach(var item in chepinMetricsData)
		{

		}
    }
}