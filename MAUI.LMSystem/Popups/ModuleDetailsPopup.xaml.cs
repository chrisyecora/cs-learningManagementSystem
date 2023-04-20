using System.Collections.ObjectModel;
using System.ComponentModel;
using CommunityToolkit.Maui.Views;
using Library.LMSystem.Models;
using MAUI.LMSystem.ViewModels;

namespace MAUI.LMSystem.Popups;

public partial class ModuleDetailsPopup : Popup, INotifyPropertyChanged
{
    public ModuleDetailsPopup(Module module)
    {
        InitializeComponent();
        BindingContext = new ModuleDetailsViewModel(module);
    }

    void CloseButton_Clicked(System.Object sender, System.EventArgs e)
    {
        Close();
    }
}
