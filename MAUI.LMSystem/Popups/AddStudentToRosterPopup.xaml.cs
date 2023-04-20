using CommunityToolkit.Maui.Views;
using Library.LMSystem.Models;
using Library.LMSystem.Services;
using MAUI.LMSystem.ViewModels;

namespace MAUI.LMSystem.Popups;

public partial class AddStudentToRosterPopup : Popup
{
    public AddStudentToRosterPopup(CourseService courseSvc, StudentService studentSvc, Course c)
    {
        InitializeComponent();
        BindingContext = new AddStudentToRosterViewModel(courseSvc, studentSvc, c);
    }

    void SumbitButton_Clicked(System.Object sender, System.EventArgs e)
    {
        (BindingContext as AddStudentToRosterViewModel).Submit();
        Close();
    }

    void CancelButton_Clicked(System.Object sender, System.EventArgs e)
    {
        Close();
    }
}
