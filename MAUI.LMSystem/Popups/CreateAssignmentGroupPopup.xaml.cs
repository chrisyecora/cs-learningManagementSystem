using CommunityToolkit.Maui.Views;
using Library.LMSystem.Models;
using Library.LMSystem.Services;
using MAUI.LMSystem.ViewModels;

namespace MAUI.LMSystem.Popups;

public partial class CreateAssignmentGroupPopup : Popup
{
    public CreateAssignmentGroupPopup(Course course, CourseService service)
    {
        InitializeComponent();
        BindingContext = new CreateAssignmentGroupViewModel(course, service);
    }

    void CancelButton_Clicked(System.Object sender, System.EventArgs e)
    {
        Close();
    }

    void SumbitButton_Clicked(System.Object sender, System.EventArgs e)
    {
        (BindingContext as CreateAssignmentGroupViewModel).Submit();
        Close();
    }
}
