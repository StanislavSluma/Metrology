using CodeParser.Jilb;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace CodeParser.Pages;

[QueryProperty("Text","Text")]
public partial class JilbMetrics : ContentPage
{
	JilbParser parser;
    public ObservableCollection<JIlbInfo> JIlbInfos { get; set; } = new();
    public JilbMetrics()
	{
		BindingContext = this;
		InitializeComponent();
		parser = new();
	}

	string text;
	public string Text 
	{
		get { return text; }
		set
		{
			text = value;
			OnPropertyChanged("Text");
		}
	}

    private void ContentPage_Loaded(object sender, EventArgs e)
    {
		var data = parser.ParseCode(Text);
		foreach(var item in data)
		{
			JIlbInfos.Add(new JIlbInfo(item.Key, item.Value));
			Trace.WriteLine(data[item.Key]);
		}
		data_grid.ItemsSource = data;
    }
}