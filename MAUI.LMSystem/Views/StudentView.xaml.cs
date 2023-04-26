using MAUI.LMSystem.ViewModels;

namespace MAUI.LMSystem.Views;

public partial class StudentView : ContentPage
{
    public StudentView()
    {
        InitializeComponent();
        BindingContext = new StudentViewViewModel();
    }

    void BackClicked(System.Object sender, System.EventArgs e) {
        Shell.Current.GoToAsync("//MainPage");
    }
}
