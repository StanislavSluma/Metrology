using CodeParser.Pages;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace CodeParser
{
    public partial class MainPage : ContentPage
    {
        private List<string> metricTypes;
        private Dictionary<int, string> metricNames = new() { {1, nameof(HolstedMetrics)},{2, nameof(JilbMetrics)},{3, nameof(ChepinMetrics)} };

        public List<string> MetricType { get; set; }
        public MainPage()
        {
            InitializeComponent();
            MetricType = new(){ "Размер программы", "Сложность потока управления программ", "Сложность потока данных" };
            BindingContext = MetricType;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (editor.Text != string.Empty && metrics_picker.SelectedIndex != -1)
            {
                //string encodedText = System.Web.HttpUtility.UrlEncode(editor.Text);
                string pattern = @"(//.*?$|/\*.*?\*/)";
                string codeWithComments = editor.Text;
                string clearText = string.Empty;
                foreach(var line in codeWithComments.Split('\r'))
                {
                    string clearLine = Regex.Replace(line, pattern, "");
                    clearText += clearLine + '\r';
                }
                IDictionary<string, object> parametrs = new Dictionary<string, object>()
                   {
                       {"Text", clearText}
                   };
                await Shell.Current.GoToAsync(metricNames[metrics_picker.SelectedIndex + 1], parametrs);
            }
        }
    }

}
