namespace EquityX.Maui
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // REGISTER FOR FREE TRIAL OF SYNC FUSION PACKAGE
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzAwNjg0MUAzMjM0MmUzMDJlMzBIcy9QS2IwaHNSYmVoazh4bkt6czBvdzZ6QU14SjRXc0FPVjl5SW5raHQwPQ==");

            MainPage = new AppShell();
        }
    }
}