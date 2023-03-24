using MAUI.LMSystem.ViewModels;
namespace MAUI.LMSystem;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        BindingContext = new MainViewModel();
    }

    void ProfessorViewButton_Clicked(System.Object sender, System.EventArgs e) {
        // change to professor view
    }

    void StudentViewButton_Clicked(System.Object sender, System.EventArgs e) {
        // change to student view
        // probably launch a dialog box to search for a student
    }

    void CreatePersonButton_Clicked(System.Object sender, System.EventArgs e)
    {
        (BindingContext as MainViewModel).CreatePerson(this);
    }

    void UpdatePersonButton_Clicked(System.Object sender, System.EventArgs e)
    {
    }

    void ViewPersonButton_Clicked(System.Object sender, System.EventArgs e)
    {
    }

    void CreateCourseButton_Clicked(System.Object sender, System.EventArgs e)
    {
    }

    void ManageCoursesButton_Clicked(System.Object sender, System.EventArgs e)
    {
    }

    void ViewCoursesButton_Clicked(System.Object sender, System.EventArgs e)
    {
    }
}


