// Author: Faran Ahmad Khan
// Author Email: L00179451@atu.ie

//namespace of Views folder
using EquityX.Maui.Views;
using EquityX.Maui.Views.Cryptos;
using EquityX.Maui.Views.Funds;
using EquityX.Maui.Views.Stocks;

namespace EquityX.Maui
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // SHELL NAVIGATION
            // REGISTER ALL THE VIEWS TO ACCESS THEM FOR NAVIGATON

            Routing.RegisterRoute(nameof(SignUpPage), typeof(SignUpPage));
            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
            Routing.RegisterRoute(nameof(PortfolioPage), typeof(PortfolioPage));
            Routing.RegisterRoute(nameof(SummaryPage), typeof(SummaryPage));
            Routing.RegisterRoute(nameof(StocksPage), typeof(StocksPage));
            Routing.RegisterRoute(nameof(CryptoPage), typeof(CryptoPage));
            Routing.RegisterRoute(nameof(MarketPage), typeof(MarketPage));
            Routing.RegisterRoute(nameof(BuyStock), typeof(BuyStock));
            Routing.RegisterRoute(nameof(BuyCrypto), typeof(BuyCrypto));
            Routing.RegisterRoute(nameof(SellStock), typeof(SellStock));
            Routing.RegisterRoute(nameof(SellCrypto), typeof(SellCrypto));
            Routing.RegisterRoute(nameof(AddFunds), typeof(AddFunds));
            Routing.RegisterRoute(nameof(WithdrawFunds), typeof(WithdrawFunds));
            Routing.RegisterRoute(nameof(PurchaseHistory), typeof(PurchaseHistory));

        }
    }
}