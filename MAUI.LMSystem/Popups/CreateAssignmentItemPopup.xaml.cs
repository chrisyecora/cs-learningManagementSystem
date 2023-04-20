using CommunityToolkit.Maui.Views;
using MAUI.LMSystem.ViewModels;
using Library.LMSystem.Models;
using Library.LMSystem.Services;

namespace MAUI.LMSystem.Popups;

public partial class CreateAssignmentItemPopup : Popup
{
    public CreateAssignmentItemPopup(CourseService svc, Module mod, Course course)
    {
        InitializeComponent();
        BindingContext = new CreateAssignmentItemViewModel(svc, mod, course);
    }

    void CancelButton_Clicked(System.Object sender, System.EventArgs e)
    {
        Close();
    }

    void SumbitButton_Clicked(System.Object sender, System.EventArgs e)
    {
        (BindingContext as CreateAssignmentItemViewModel).Submit();
        Close();
    }
}
