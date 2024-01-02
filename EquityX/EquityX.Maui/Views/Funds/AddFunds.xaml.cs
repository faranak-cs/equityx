// Author: Faran Ahmad Khan
// Author Email: L00179451@atu.ie

using EquityX.Maui.ViewModels;

namespace EquityX.Maui.Views.Funds;


[QueryProperty(nameof(UserId), "id")]
public partial class AddFunds : ContentPage
{
    // CREATE OBJECT OF USER CLASS
    private Models.User user;
    public AddFunds()
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



    // HANDLE ADD FUNDS
    private void fundCtrl_OnConfirm(object sender, EventArgs e)
    {
        double amountAdded = double.Parse(fundCtrl.Amount);

        // PASS AMOUNT AND USER ID TO HOME VIEW MODEL FUNCTION
        string response = HomePageViewModel.AddFunds(user.Id, amountAdded);

        // AMOUNT IS ADD
        if (response == "y")
        {
            DisplayAlert("Status", "Amount is added to your wallet", "OK");
            Shell.Current.GoToAsync("..");

        }
        // AMOUNT IS NOT ADDED
        else
        {
            DisplayAlert("Status", "Sorry we don't have enough money", "OK");
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