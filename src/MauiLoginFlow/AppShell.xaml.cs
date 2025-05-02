using MauiLoginFlow.Views;

namespace MauiLoginFlow
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        }
    }
}
