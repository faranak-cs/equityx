// Author: Faran Ahmad Khan
// Author Email: L00179451@atu.ie

using EquityX.Maui.DataSource;

namespace EquityX.Maui.Views;
public partial class SignUpPage : ContentPage
{
    private RESTManager RESTManager;
    public SignUpPage()
    {
        InitializeComponent();
        RESTManager = new RESTManager();
    }
    private async void btnSignUp_Clicked(object sender, EventArgs e)
    {
        await RESTManager.GetStockRestData();
        await RESTManager.GetCryptoRestData();
        await Shell.Current.GoToAsync(nameof(HomePage));
    }
}