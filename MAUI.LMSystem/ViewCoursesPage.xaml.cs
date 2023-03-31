using Library.LMSystem.Models;
using Library.LMSystem.Services;
using MAUI.LMSystem.ViewModels;
namespace MAUI.LMSystem;

public partial class ViewCoursesPage : ContentPage
{
    public ViewCoursesPage(CourseService service)
    {
        InitializeComponent();
        BindingContext = new ViewCoursesViewModel(service);
    }

    void Search_Clicked(System.Object sender, System.EventArgs e)
    {
    }
}
