using CommunityToolkit.Maui.Views;
using Library.LMSystem.Models;
using Library.LMSystem.Services;
using MAUI.LMSystem.ViewModels;

namespace MAUI.LMSystem.Popups;

public partial class GradeAssignmentPopup : Popup
{
    public GradeAssignmentPopup(Course c, StudentService svc)
    {
        InitializeComponent();
        BindingContext = new GradeAssignmentViewModel(c, svc);
    }

    void SumbitButton_Clicked(System.Object sender, System.EventArgs e)
    {
        (BindingContext as GradeAssignmentViewModel).Submit();
        Close();
    }

    void CancelButton_Clicked(System.Object sender, System.EventArgs e)
    {
        Close();
    }
}
