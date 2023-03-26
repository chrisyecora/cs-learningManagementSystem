using CommunityToolkit.Maui.Views;
using Library.LMSystem.Services;
using MAUI.LMSystem.ViewModels;
namespace MAUI.LMSystem.Popups;

public partial class CreateCoursePopup : Popup {
    private CourseService service;
    public CreateCoursePopup(CourseService courseService) {
        InitializeComponent();
        service = courseService;
        BindingContext = new CreateCourseViewModel();
    }

    void CancelButton_Clicked(System.Object sender, System.EventArgs e) {
        Close();
    }

    void SumbitButton_Clicked(System.Object sender, System.EventArgs e) {
        (BindingContext as CreateCourseViewModel).CreateCourse(service);
        Close();
    }
}
