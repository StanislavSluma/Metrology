using CodeParser.Pages;

namespace CodeParser
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(HolstedMetrics), typeof(HolstedMetrics));
            Routing.RegisterRoute(nameof(JilbMetrics), typeof(JilbMetrics));
            Routing.RegisterRoute(nameof(ChepinMetrics), typeof(ChepinMetrics));
        }
    }
}
