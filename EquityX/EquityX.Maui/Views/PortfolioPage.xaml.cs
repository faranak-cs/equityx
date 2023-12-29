namespace EquityX.Maui.Views;

using EquityX.Maui.ViewModels;
using System.Collections.ObjectModel;


public partial class PortfolioPage : ContentPage
{
    public PortfolioPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        var assets = new ObservableCollection<Models.Assets>(PortfolioPageViewModel.GetAssets());
        listAssets.ItemsSource = assets;
        lblAsset.Text = "$" + PortfolioPageViewModel.GetSum().ToString();
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