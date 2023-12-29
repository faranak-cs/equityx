using EquityX.Maui.ViewModels;
using System.Collections.ObjectModel;

namespace EquityX.Maui.Views;

public partial class IndividualSummary : ContentPage
{
    public IndividualSummary()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        var assets = new ObservableCollection<Models.Assets>(PortfolioPageViewModel.GetAssets());
        listAssets.ItemsSource = assets;
    }
}