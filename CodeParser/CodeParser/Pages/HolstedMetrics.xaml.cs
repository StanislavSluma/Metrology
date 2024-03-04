using CodeParser.Holsted;
using System.Collections.ObjectModel;

namespace CodeParser.Pages;

[QueryProperty("Text","Text")]
public partial class HolstedMetrics : ContentPage
{
    HolstedParser holstedParser;
    public ObservableCollection<HolstedInfo> OperatorsInfo { get; set; } = new();
    public ObservableCollection<HolstedInfo> OperandsInfo { get; set; } = new();
    /*   public ObservableCollection<HolstedInfo> HolstedInfos 
       { 
           get { return _holstedInfo; } 
           set
           {
               if (_holstedInfo != value) { _holstedInfo =  value; OnPropertyChanged(); }
           }
       }*/

    public HolstedMetrics()
	{
        BindingContext = this;
        InitializeComponent();
        holstedParser = new HolstedParser();
    }

    string text;
	public string Text 
	{ 
		get => text;
		set
		{
			text = value;
			OnPropertyChanged("Text");
        }
	}

    private void ContentPage_Loaded(object sender, EventArgs e)
    {
        var data = holstedParser.ParseCode(Text);
        var data1 = data.Item1;
        var data2 = data.Item2;
        var index1 = 0;
        var index2 = 0;
        var N1 = 0;
        var N2 = 0;
        foreach (var item in data1)
        {
            if (item.Key != null && item.Value != 0)
            {
                OperatorsInfo.Add(new HolstedInfo(++index1, item.Key, item.Value));
                N1 += item.Value;
            }
        }
        foreach (var item in data2)
        {
            if (item.Key != null && item.Value != 0)
            {
                OperandsInfo.Add(new HolstedInfo(++index2, item.Key, item.Value));
                N2 += item.Value;
            }
        }
        OperatorsInfo.Add(new HolstedInfo(index1,"", N1));
        OperandsInfo.Add(new HolstedInfo(index2, "", N2));
        var prog_dict = index1 + index2;
        var prog_len = N1 + N2;
        var prog_volume = prog_len * Math.Log2(prog_dict);
        dictionary_label.Text += prog_dict;
        length_label.Text += prog_len;
        volume_label.Text += prog_volume;
    }
}