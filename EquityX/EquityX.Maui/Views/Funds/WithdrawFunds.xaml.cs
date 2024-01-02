// Author: Faran Ahmad Khan
// Author Email: L00179451@atu.ie

using EquityX.Maui.ViewModels;

namespace EquityX.Maui.Views.Funds;


[QueryProperty(nameof(UserId), "id")]
public partial class WithdrawFunds : ContentPage
{
    // CREATE OBJECT OF USER CLASS
    private Models.User user;
    public WithdrawFunds()
    {
        InitializeComponent();
    }


    // CREATE "USERID" PROPERTY TO GET ALL DETAILS
    public string UserId
    {
        set
        {
            user = HomePageViewModel.GetUserById(int.Parse(value));
            if (user != null)
            {
                fundCtrl.Owner = user.Name;

                fundCtrl.AvailableFunds = user.Funds.ToString();

                fundCtrl.Amount = 100.ToString();

            }
        }
    }

    // HANDLE WITHDRAW FUNDS
    private void fundCtrl_OnConfirm(object sender, EventArgs e)
    {
        double amountWithdrawn = double.Parse(fundCtrl.Amount);

        // PASS AMOUNT AND USER ID TO HOME VIEW MODEL FUNCTION
        string response = HomePageViewModel.WithdrawFunds(user.Id, amountWithdrawn);

        // AMOUNT IS WITHDRAWN
        if (response == "y")
        {
            DisplayAlert("Status", "Amount is withdrawn from your wallet", "OK");
            Shell.Current.GoToAsync("..");

        }
        // AMOUNT IS NOT WITHDRAWN
        else
        {
            DisplayAlert("Status", "Sorry you can't withdraw at the moment", "OK");
            Shell.Current.GoToAsync("..");
        }
    }

    // RETURN TO HOME PAGE ON CANCEL
    private void fundCtrl_OnCancel(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"..");
    }


    // DISPLAY ERROR
    private void fundCtrl_OnError(object sender, string e)
    {
        DisplayAlert("Error", e, "OK");
    }
}