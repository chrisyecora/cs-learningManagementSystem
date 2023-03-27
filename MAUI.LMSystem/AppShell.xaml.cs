namespace MAUI.LMSystem;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(ViewPersonsPage), typeof(ViewPersonsPage));
    }
}

