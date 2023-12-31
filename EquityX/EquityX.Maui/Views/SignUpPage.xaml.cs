namespace EquityX.Maui.Views;
public partial class SignUpPage : ContentPage
{
    public SignUpPage()
    {
        InitializeComponent();
    }

    private void btnSignUp_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(HomePage));
    }
}