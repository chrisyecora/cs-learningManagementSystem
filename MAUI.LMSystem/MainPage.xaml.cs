using MAUI.LMSystem.ViewModels;

namespace MAUI.LMSystem;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        BindingContext = new MainViewModel();
    }
}


