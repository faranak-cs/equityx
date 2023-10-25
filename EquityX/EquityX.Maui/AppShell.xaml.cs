//namespace of Views folder
using EquityX.Maui.Views;

namespace EquityX.Maui
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(SignUpPage), typeof(SignUpPage));
            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
            Routing.RegisterRoute(nameof(PortfolioPage), typeof(PortfolioPage));
            Routing.RegisterRoute(nameof(SummaryPage), typeof(SummaryPage));
            Routing.RegisterRoute(nameof(StocksPage), typeof(StocksPage));
            Routing.RegisterRoute(nameof(CryptoPage), typeof(CryptoPage));
            Routing.RegisterRoute(nameof(MarketPage), typeof(MarketPage));




        }
    }
}