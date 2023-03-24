namespace MAUI.LMSystem.Popups;
using CommunityToolkit.Maui.Views;
using Library.LMSystem.Services;
using MAUI.LMSystem.ViewModels;

public partial class CreatePersonPopup : Popup
{
    private StudentService service;
    public CreatePersonPopup(StudentService studentService)
    {
        InitializeComponent();
        service = studentService;
        BindingContext = new CreatePersonViewModel();
    }

    void CancelButton_Clicked(System.Object sender, System.EventArgs e)
    {
        Close();
    }

    void SumbitButton_Clicked(System.Object sender, System.EventArgs e)
    {
        // take data from Properties and add it into the service
        (BindingContext as CreatePersonViewModel).CreatePerson(service);
        Close();
    }
}
