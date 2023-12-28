namespace EquityX.Maui.Views;

using EquityX.Maui.ViewModels;
using System.Collections.ObjectModel;

//ids are named different, if same then both are added
[QueryProperty(nameof(StockId), "stockid")]
[QueryProperty(nameof(CryptoId), "cryptoid")]

public partial class PortfolioPage : ContentPage
{
    private EquityX.Maui.Models.Crypto crypto;
    private EquityX.Maui.Models.Stocks stocks;

    public PortfolioPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        var assets = new ObservableCollection<EquityX.Maui.Models.Assets>(PortfolioPageViewModel.GetAssets());
        listAssets.ItemsSource = assets;
        lblAsset.Text = "$" + PortfolioPageViewModel.GetSum().ToString();
    }

    // "CryptoId" PROPERTY
    public string CryptoId
    {
        set
        {
            crypto = CryptoPageViewModel.GetCryptoById(int.Parse(value));

            PortfolioPageViewModel.AddAsset(new Models.Assets
            {

                Name = crypto.Name,
                Investment = crypto.Price
            });
        }
    }

    // "StockId" PROPERTY
    public string StockId
    {
        set
        {
            stocks = StocksPageViewModel.GetStockById(int.Parse(value));

            PortfolioPageViewModel.AddAsset(new Models.Assets
            {
                Name = stocks.Name,
                Investment = stocks.Price
            });
        }
    }

    private void btnHome_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(HomePage));
    }

    private void listAssets_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        // LOGIC
    }
}