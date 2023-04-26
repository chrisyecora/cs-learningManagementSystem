using CommunityToolkit.Maui.Views;
using Library.LMSystem.Models;
using Library.LMSystem.Services;
using MAUI.LMSystem.ViewModels;

namespace MAUI.LMSystem.Popups;

public partial class RemoveStudentFromRosterPopup : Popup
{
    public RemoveStudentFromRosterPopup(CourseService courseSvc, Course c)
    {
        InitializeComponent();
        BindingContext = new RemoveStudentFromRosterViewModel(courseSvc, c);
    }

    void CancelButton_Clicked(System.Object sender, System.EventArgs e)
    {
        Close();
    }

    void SumbitButton_Clicked(System.Object sender, System.EventArgs e)
    {
        (BindingContext as RemoveStudentFromRosterViewModel).Submit();
        Close();
    }
}
