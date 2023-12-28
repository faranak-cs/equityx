using EquityX.Maui.ViewModels;
using System.Collections.ObjectModel;

namespace EquityX.Maui.Views;



public partial class SummaryPage : ContentPage
{
    private EquityX.Maui.Models.Crypto crypto;
    private EquityX.Maui.Models.Stocks stocks;
    public SummaryPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        var assets = new ObservableCollection<EquityX.Maui.Models.Assets>(PortfolioPageViewModel.GetAssets());
        listAssets.ItemsSource = assets;
    }


    private void btnHome_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(HomePage));
    }
}