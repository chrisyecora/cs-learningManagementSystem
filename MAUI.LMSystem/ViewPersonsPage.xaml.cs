namespace MAUI.LMSystem;

using Library.LMSystem.Services;
using MAUI.LMSystem.ViewModels;
public partial class ViewPersonsPage : ContentPage
{
    private StudentService studentService;
    public ViewPersonsPage(StudentService service)
    {
        InitializeComponent();
        studentService = service;
        BindingContext = new ViewPersonsViewModel(service);
    }

    void Search_Clicked(System.Object sender, System.EventArgs e)
    {
    }
}
