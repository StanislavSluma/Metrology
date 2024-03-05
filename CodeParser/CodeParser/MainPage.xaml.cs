using CodeParser.Pages;

namespace CodeParser
{
    public partial class MainPage : ContentPage
    {
        private List<string> metricTypes;
        private Dictionary<int, string> metricNames = new() { {1,nameof(HolstedMetrics)},{2,nameof(JilbMetrics)},{3,nameof(ChepinMetrics)} };

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
                string encodedText = System.Web.HttpUtility.UrlEncode(editor.Text);
                IDictionary<string, object> parametrs = new Dictionary<string, object>()
                {
                    {"Text", encodedText}
                };
                await Shell.Current.GoToAsync(metricNames[metrics_picker.SelectedIndex + 1], parametrs);
            }
        }
    }

}
