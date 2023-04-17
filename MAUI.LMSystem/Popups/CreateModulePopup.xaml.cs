using CommunityToolkit.Maui.Views;
using Library.LMSystem.Models;
using Library.LMSystem.Services;
using MAUI.LMSystem.ViewModels;

namespace MAUI.LMSystem.Popups;

public partial class CreateModulePopup : Popup
{
    public CreateModulePopup(CourseService svc, Course course)
    {
        InitializeComponent();
        BindingContext = new CreateModuleViewModel(svc, course);
    }

    void CancelButton_Clicked(System.Object sender, System.EventArgs e) {
        Close();
    }

    void SumbitButton_Clicked(System.Object sender, System.EventArgs e)
    {
        (BindingContext as CreateModuleViewModel).Submit();
        Close();
    }
}
