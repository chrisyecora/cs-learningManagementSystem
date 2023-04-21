using CommunityToolkit.Maui.Views;
using Library.LMSystem.Models;
using Library.LMSystem.Services;
using MAUI.LMSystem.ViewModels;

namespace MAUI.LMSystem.Popups;

public partial class ModifyCourseDetailsPopup : Popup
{
    public ModifyCourseDetailsPopup(CourseService svc, Course c)
    {
        InitializeComponent();
        BindingContext = new ModifyCourseDetailsViewModel(svc, c);
    }

    void SumbitButton_Clicked(System.Object sender, System.EventArgs e)
    {
        (BindingContext as ModifyCourseDetailsViewModel).Submit();
        Close();
    }

    void CancelButton_Clicked(System.Object sender, System.EventArgs e)
    {
        Close();
    }
}
