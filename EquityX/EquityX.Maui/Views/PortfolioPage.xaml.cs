namespace EquityX.Maui.Views;

using EquityX.Maui.ViewModels;
using System.Collections.ObjectModel;

//ids are named different, if same then both are added
[QueryProperty(nameof(StockId), "stocksid")]
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
        var assets = new ObservableCollection<EquityX.Maui.Models.Assets>(PortfolioPageViewModel.GetUniqueAssets());
        listAssets.ItemsSource = assets;
        lblAsset.Text = "$" + PortfolioPageViewModel.GetSum().ToString();

    }

    //i have to create a property called CryptoId that gets updated according to the id
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

            //listAssets.ItemsSource=new List<Crypto> { crypto };
        }
    }

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

    }
}