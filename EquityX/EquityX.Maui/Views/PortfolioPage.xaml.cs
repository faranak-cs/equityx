using EquityX.Maui.ViewModels;
using System.Collections.ObjectModel;

namespace EquityX.Maui.Views;
public partial class PortfolioPage : ContentPage
{
    public PortfolioPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        var assets = new ObservableCollection<Models.Asset>(PortfolioPageViewModel.GetAssets());
        listAssets.ItemsSource = assets;
        lblAsset.Text = "$" + PortfolioPageViewModel.GetSum().ToString();
    }

    private void btnHome_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(HomePage));
    }

}