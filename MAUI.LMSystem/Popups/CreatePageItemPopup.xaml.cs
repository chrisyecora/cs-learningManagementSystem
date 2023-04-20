using CommunityToolkit.Maui.Views;
using Library.LMSystem.Models;
using Library.LMSystem.Services;
using MAUI.LMSystem.ViewModels;

namespace MAUI.LMSystem.Popups;

public partial class CreatePageItemPopup : Popup
{
    public CreatePageItemPopup(CourseService svc, Module mod)
    {
        InitializeComponent();
        BindingContext = new CreatePageItemViewModel(svc, mod);
    }

    void SumbitButton_Clicked(System.Object sender, System.EventArgs e)
    {
        (BindingContext as CreatePageItemViewModel).Submit();
        Close();
    }

    void CancelButton_Clicked(System.Object sender, System.EventArgs e)
    {
        
        Close();
    }
}
