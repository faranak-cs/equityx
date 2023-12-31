using EquityX.Maui.ViewModels;
using System.Collections.ObjectModel;

namespace EquityX.Maui.Views;
public partial class SummaryPage : ContentPage
{
    public SummaryPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        var assets = new ObservableCollection<Models.Asset>(PortfolioPageViewModel.GetAssets());
        listAssets.ItemsSource = assets;
    }

    private async void listAssets_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (listAssets.SelectedItem != null)
        {
            await Shell.Current.GoToAsync(nameof(PurchaseHistory));
            listAssets.SelectedItem = null;
        }
    }
}