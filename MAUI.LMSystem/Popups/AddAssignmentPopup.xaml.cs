using CommunityToolkit.Maui.Views;
using Library.LMSystem.Models;
using Library.LMSystem.Services;
using MAUI.LMSystem.ViewModels;

namespace MAUI.LMSystem.Popups;

public partial class AddAssignmentPopup : Popup
{

    
    public AddAssignmentPopup(Course course, CourseService service)
    {
        InitializeComponent();
        BindingContext = new AddAssignmentViewModel(course, service);
    }

    void CancelButton_Clicked(System.Object sender, System.EventArgs e)
    {
        Close();
    }

    void SumbitButton_Clicked(System.Object sender, System.EventArgs e)
    {
        (BindingContext as AddAssignmentViewModel).Submit();
        Close();
    }
}
