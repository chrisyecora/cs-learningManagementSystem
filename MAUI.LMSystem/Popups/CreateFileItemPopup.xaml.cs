using CommunityToolkit.Maui.Views;
using Library.LMSystem.Models;
using Library.LMSystem.Services;
using MAUI.LMSystem.ViewModels;

namespace MAUI.LMSystem.Popups;

public partial class CreateFileItemPopup : Popup
{
    public CreateFileItemPopup(CourseService svc, Module mod)
    {
        InitializeComponent();
        BindingContext = new CreateFileItemViewModel(svc, mod);
    }

    void CancelButton_Clicked(System.Object sender, System.EventArgs e)
    {
        Close();
    }

    void SumbitButton_Clicked(System.Object sender, System.EventArgs e)
    {
        (BindingContext as CreateFileItemViewModel).Submit();
        Close();
    }
}
