using MAUI.LMSystem.ViewModels;
namespace MAUI.LMSystem;

public partial class MainPage : ContentPage
{
    public MainPage(MainViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    void ProfessorViewButton_Clicked(System.Object sender, System.EventArgs e) {
        
    }

    void StudentViewButton_Clicked(System.Object sender, System.EventArgs e) {
        Shell.Current.GoToAsync("//Student");
    } 
}


