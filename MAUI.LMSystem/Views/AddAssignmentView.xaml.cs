using MAUI.LMSystem.ViewModels;

namespace MAUI.LMSystem.Views;

public partial class AddAssignmentView : ContentPage
{
    public AddAssignmentView()
    {
        InitializeComponent();
        BindingContext = new AddAssignmentViewModel();
    }
}
