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
        await RESTManager.GetRestData();
        await Shell.Current.GoToAsync(nameof(HomePage));
    }
}