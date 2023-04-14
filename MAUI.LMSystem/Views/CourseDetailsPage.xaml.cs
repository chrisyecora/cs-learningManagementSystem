using MAUI.LMSystem.ViewModels;

namespace MAUI.LMSystem.Views;

public partial class CourseDetailsPage : ContentPage
{
    public CourseDetailsPage()
    {
        InitializeComponent();
        BindingContext = new CourseDetailsViewModel();
    }
}
