namespace MAUI.LMSystem.Views;
using MAUI.LMSystem.ViewModels;

public partial class InstructorView : ContentPage
{
    public InstructorView()
    {
        InitializeComponent();
        BindingContext = new InstructorViewViewModel();
    }

    void BackClicked(System.Object sender, System.EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }

    void CreatePersonButton_Clicked(System.Object sender, System.EventArgs e) {
        (BindingContext as InstructorViewViewModel).CreatePerson(this);
    }

    void UpdatePersonButton_Clicked(System.Object sender, System.EventArgs e) {
    }

    void CreateCourseButton_Clicked(System.Object sender, System.EventArgs e) {
        (BindingContext as InstructorViewViewModel).CreateCourse(this);
    }

    void ManageCoursesButton_Clicked(System.Object sender, System.EventArgs e) {
    }
}
