namespace EquityX.Maui.Views.Controls;

public partial class CryptosControl : ContentView
{
    public event EventHandler<string> OnError;
    public event EventHandler<EventArgs> OnConfirm;
    public event EventHandler<EventArgs> OnCancel;

    public CryptosControl()
    {
        InitializeComponent();
    }

    // CRYPTO NAME PROPERTY
    public string Crypto
    {
        get
        {
            return entryCrypto.Text;
        }
        set { entryCrypto.Text = value; }
    }

    // CRYPTO PRICE PROPERTY
    public string Price
    {
        get
        {
            return entryPrice.Text;
        }
        set { entryPrice.Text = value; }
    }

    // CRYPTO UNIT PROPERTY
    public string Unit
    {
        get
        {
            return entryUnit.Text;
        }
        set { entryUnit.Text = value; }
    }

    private void btnConfirm_Clicked(object sender, EventArgs e)
    {
        if (unitValidator.IsNotValid)
        {
            OnError?.Invoke(sender, "Please enter the unit between 1 and 5");
            return;
        }
        OnConfirm?.Invoke(sender, e);
    }

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        OnCancel?.Invoke(sender, e);
    }
}