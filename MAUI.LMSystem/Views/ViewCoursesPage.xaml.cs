using Library.LMSystem.Models;
using Library.LMSystem.Services;
using MAUI.LMSystem.ViewModels;
namespace MAUI.LMSystem.Views;
public partial class ViewCoursesPage : ContentPage
{
    public ViewCoursesPage()
    {
        InitializeComponent();
        BindingContext = new ViewCoursesViewModel();
    }
}
