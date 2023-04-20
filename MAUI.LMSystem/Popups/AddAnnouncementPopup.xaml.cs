using CommunityToolkit.Maui.Views;
using Library.LMSystem.Models;
using Library.LMSystem.Services;
using MAUI.LMSystem.ViewModels;

namespace MAUI.LMSystem.Popups;

public partial class AddAnnouncementPopup : Popup
{
    public AddAnnouncementPopup(CourseService courseService, Course course)
    {
        InitializeComponent();
        BindingContext = new AddAnnouncementViewModel(courseService, course);
    }

    void CancelButton_Clicked(System.Object sender, System.EventArgs e)
    {
        Close();
    }

    void SumbitButton_Clicked(System.Object sender, System.EventArgs e)
    {
        (BindingContext as AddAnnouncementViewModel).Submit();
        Close();
    }
}
