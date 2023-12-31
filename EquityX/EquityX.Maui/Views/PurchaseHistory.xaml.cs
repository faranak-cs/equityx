using EquityX.Maui.ViewModels;
using System.Collections.ObjectModel;

namespace EquityX.Maui.Views;
public partial class PurchaseHistory : ContentPage
{
    public PurchaseHistory()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        PortfolioPageViewModel.UpdateSummary();
        var assets = new ObservableCollection<Models.Asset>(PortfolioPageViewModel.GetAssets());
        listAssets.ItemsSource = assets;
    }
}