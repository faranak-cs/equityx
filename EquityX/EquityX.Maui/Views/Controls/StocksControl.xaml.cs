// Author: Faran Ahmad Khan
// Author Email: L00179451@atu.ie

namespace EquityX.Maui.Views.Controls;

public partial class StocksControl : ContentView
{
    public event EventHandler<string> OnError;
    public event EventHandler<EventArgs> OnConfirm;
    public event EventHandler<EventArgs> OnCancel;

    public StocksControl()
    {
        InitializeComponent();
    }

    // STOCK NAME PROPERTY
    public string Stock
    {
        get
        {
            return entryStock.Text;
        }
        set { entryStock.Text = value; }
    }

    // STOCK PRICE PROPERTY
    public string Price
    {
        get
        {
            return entryPrice.Text;
        }
        set { entryPrice.Text = value; }
    }

    // STOCK UNIT PROPERTY
    public string Unit
    {
        get
        {
            return entryUnit.Text;
        }
        set { entryUnit.Text = value; }
    }

    // VALIDATE ? SHOULD BE {1,2,3,4,5}
    private bool IsValidEntryValue(string value)
    {
        if (double.TryParse(value, out double numericValue))
        {
            return numericValue >= 1 && numericValue <= 5 && numericValue % 1 == 0;
        }
        return false;
    }

    private void btnConfirm_Clicked(object sender, EventArgs e)
    {
        string input = entryUnit.Text;

        // CHECK ? SHOULD BE >=1 AND <=5
        if (unitValidator.IsNotValid)
        {
            OnError?.Invoke(sender, "Please enter the unit between 1 and 5");
            return;
        }

        // CHECK ? SHOULD BE {1,2,3,4,5}
        if (!IsValidEntryValue(input))
        {
            OnError?.Invoke(sender, "Sorry fractional units are not available");
            return;
        }

        // PASSED
        OnConfirm?.Invoke(sender, e);
    }

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        OnCancel?.Invoke(sender, e);
    }
}