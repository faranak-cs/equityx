namespace EquityX.Maui.Views;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
	}

    private void btnAddFunds_Clicked(object sender, EventArgs e)
    {

    }

    private void imgPortfolio_Tapped(object sender, TappedEventArgs e)
    {
        
        Shell.Current.GoToAsync(nameof(PortfolioPage));
    }

    private void imgSummary_Tapped(object sender, TappedEventArgs e)
    {

        Shell.Current.GoToAsync(nameof(SummaryPage));
    }

    private void imgStocks_Tapped(object sender, TappedEventArgs e)
    {

        Shell.Current.GoToAsync(nameof(StocksPage));
    }

    private void imgCrypto_Tapped(object sender, TappedEventArgs e)
    {

        Shell.Current.GoToAsync(nameof(CryptoPage));
    }

    private void imgMarket_Tapped(object sender, TappedEventArgs e)
    {

        Shell.Current.GoToAsync(nameof(MarketPage));
    }

}