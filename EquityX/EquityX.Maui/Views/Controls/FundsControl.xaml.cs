// Author: Faran Ahmad Khan
// Author Email: L00179451@atu.ie

namespace EquityX.Maui.Views.Controls;

public partial class FundsControl : ContentView
{
    public event EventHandler<string> OnError;
    public event EventHandler<EventArgs> OnConfirm;
    public event EventHandler<EventArgs> OnCancel;

    public FundsControl()
    {
        InitializeComponent();
    }

    // FUNDS AMOUNT PROPERTY
    public string Amount
    {
        get
        {
            return entryAmount.Text;
        }
        set { entryAmount.Text = value; }
    }

    // FUNDS OWNER PROPERTY
    public string Owner
    {
        get
        {
            return entryOwner.Text;
        }
        set { entryOwner.Text = value; }
    }

    // FUNDS AVAILABLE PROPERTY
    public string AvailableFunds
    {
        get
        {
            return entryAvailableFunds.Text;
        }
        set { entryAvailableFunds.Text = value; }
    }


    // CONFIRM BUTTON HANDLER
    private void btnConfirm_Clicked(object sender, EventArgs e)
    {
        if (amountValidator.IsNotValid)
        {
            OnError?.Invoke(sender, "Enter amount between 100 and 500");
            return;
        }
        OnConfirm?.Invoke(sender, e);
    }

    // CANCEL BUTTON HANDLER
    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        OnCancel?.Invoke(sender, e);
    }

}