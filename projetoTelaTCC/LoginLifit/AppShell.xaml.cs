using LoginLifit.Views;

namespace LoginLifit;

public partial class AppShell : Shell
{
    public AppShell()
    {
        // Esta linha é a única coisa relacionada a InitializeComponent que deve existir.
        InitializeComponent();

        Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
        Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
    }
}