// Author: Faran Ahmad Khan
// Author Email: L00179451@atu.ie

using EquityX.Maui.ViewModels;

namespace EquityX.Maui.Views.Cryptos;

[QueryProperty(nameof(CryptoId), "id")]
public partial class SellCrypto : ContentPage
{
    // CREATE OBJECT OF CRYPTO CLASS
    private Models.Crypto crypto;
    public SellCrypto()
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
                cryptoCtrl.Price = crypto.MarketPrice.ToString();
                // CRYPTOCTRL UNIT DATA TYPE IS STRING
                cryptoCtrl.Unit = 1.ToString();
            }
        }
    }

    // HANDLE CRYPTO SELL
    private void cryptoCtrl_OnConfirm(object sender, EventArgs e)
    {
        int cryptoUnit = int.Parse(cryptoCtrl.Unit);

        // PASS CRYPTO UNIT AND CRYPTO ID TO CRYPTO VIEW MODEL FUNCTION
        string response = CryptoPageViewModel.SellCryptoByUnit(cryptoUnit, crypto.MarketPrice, crypto.Name);

        // CRYPTO IS SOLD
        if (response == "y")
        {
            DisplayAlert("Status", "Cryptocurrency is sold", "OK");
            Shell.Current.GoToAsync("..");

        }
        // CRYPTO IS NOT SOLD
        else
        {
            DisplayAlert("Status", "Insufficient units to sell cryptocurrency", "OK");
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