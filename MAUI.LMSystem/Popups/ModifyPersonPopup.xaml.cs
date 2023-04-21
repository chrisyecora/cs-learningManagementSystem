using CommunityToolkit.Maui.Views;
using Library.LMSystem.Models;
using Library.LMSystem.Services;
using MAUI.LMSystem.ViewModels;

namespace MAUI.LMSystem.Popups;

public partial class ModifyPersonPopup : Popup
{
    public ModifyPersonPopup(Person person, StudentService svc)
    {
        InitializeComponent();
        BindingContext = new ModifyPersonViewModel(person, svc);
    }

    void SumbitButton_Clicked(System.Object sender, System.EventArgs e)
    {
        (BindingContext as ModifyPersonViewModel).Submit();
        Close();
    }

    void CancelButton_Clicked(System.Object sender, System.EventArgs e)
    {
        Close();
    }
}
