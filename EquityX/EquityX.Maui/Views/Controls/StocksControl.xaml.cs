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

    private void btnConfirm_Clicked(object sender, EventArgs e)
    {
        if (unitValidator.IsNotValid)
        {
            OnError?.Invoke(sender, "Please enter the unit");
            return;
        }
        OnConfirm?.Invoke(sender, e);
    }

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        OnCancel?.Invoke(sender, e);
    }
}