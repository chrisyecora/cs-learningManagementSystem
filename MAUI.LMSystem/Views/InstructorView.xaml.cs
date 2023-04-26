namespace MAUI.LMSystem.Views;
using MAUI.LMSystem.ViewModels;

public partial class InstructorView : ContentPage
{
    public InstructorView()
    {
        InitializeComponent();
        BindingContext = new InstructorViewViewModel();
    }
}
