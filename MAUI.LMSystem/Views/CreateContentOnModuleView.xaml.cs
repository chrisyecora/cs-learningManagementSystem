using MAUI.LMSystem.ViewModels;

namespace MAUI.LMSystem.Views;

public partial class CreateContentOnModuleView : ContentPage
{
    public CreateContentOnModuleView()
    {
        InitializeComponent();
        BindingContext = new CreateContentOnModuleViewModel();
    }
}
