using MAUI.LMSystem.ViewModels;
namespace MAUI.LMSystem;

public partial class MainPage : ContentPage
{
    public MainPage(MainViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    void ProfessorViewButton_Clicked(System.Object sender, System.EventArgs e) {
        Shell.Current.GoToAsync("//Instructor");
    }

    void StudentViewButton_Clicked(System.Object sender, System.EventArgs e) {
        Shell.Current.GoToAsync("//Student");
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
        (BindingContext as MainViewModel).ViewPersons(this);
    }

    void CreateCourseButton_Clicked(System.Object sender, System.EventArgs e)
    {
        (BindingContext as MainViewModel).CreateCourse(this);
    }

    void ManageCoursesButton_Clicked(System.Object sender, System.EventArgs e)
    {
    }

    
}


