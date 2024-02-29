using CodeParser.Jilb;

namespace CodeParser.Pages;

[QueryProperty("Text","Text")]
public partial class JilbMetrics : ContentPage
{
	JilbParser parser;
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
		parser.ParseCode(Text);
    }
}