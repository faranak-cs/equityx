//namespace of Views folder
using EquityX.Maui.Views;

namespace EquityX.Maui
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(SignUpPage), typeof(SignUpPage));
            
        }
    }
}