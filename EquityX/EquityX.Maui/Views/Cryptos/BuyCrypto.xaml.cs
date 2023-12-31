using EquityX.Maui.ViewModels;

namespace EquityX.Maui.Views.Cryptos;

[QueryProperty(nameof(CryptoId), "id")]
public partial class BuyCrypto : ContentPage
{
    // CREATE OBJECT OF CRYPTO CLASS
    private Models.Crypto crypto;
    public BuyCrypto()
    {
        InitializeComponent();
    }

    // CREATE "CryptoId" PROPERTY TO GET ALL DETAILS
    public string CryptoId
    {
        set
        {
            crypto = CryptoPageViewModel.GetCryptoById(int.Parse(value));
            if (crypto != null)
            {
                cryptoCtrl.Crypto = crypto.Name;
                // CRYPTOCTRL PRICE DATA TYPE IS STRING
                cryptoCtrl.Price = crypto.Price.ToString();
                // CRYPTOCTRL UNIT DATA TYPE IS STRING
                cryptoCtrl.Unit = 1.ToString();
            }
        }
    }

    // HANDLE CRYPTO BUY
    private void cryptoCtrl_OnConfirm(object sender, EventArgs e)
    {
        int cryptoUnit = int.Parse(cryptoCtrl.Unit);

        // PASS CRYPTO UNIT AND CRYPTO ID TO CRYPTO VIEW MODEL FUNCTION
        string response = CryptoPageViewModel.BuyCryptoByUnit(cryptoUnit, crypto.CryptoId);

        // CRYPTO IS BOUGHT
        if (response == "y")
        {
            DisplayAlert("Status", "Cryptocurrency is bought", "OK");
            Shell.Current.GoToAsync("..");

        }
        // CRYPTO IS NOT BOUGHT
        else
        {
            DisplayAlert("Status", "Insufficient funds to buy cryptocurrency", "OK");
            Shell.Current.GoToAsync("..");
        }
    }

    // RETURN TO CRYPTO PAGE ON CANCEL
    private void cryptoCtrl_OnCancel(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"..");
    }

    // DISPLAY ERROR
    private void cryptoCtrl_OnError(object sender, string e)
    {
        DisplayAlert("Error", e, "OK");
    }
}