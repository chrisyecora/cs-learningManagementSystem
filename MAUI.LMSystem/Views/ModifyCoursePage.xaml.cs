using MAUI.LMSystem.ViewModels;

namespace MAUI.LMSystem.Views;

public partial class ModifyCoursePage : ContentPage
{
    public ModifyCoursePage()
    {
        InitializeComponent();
        BindingContext = new ModifyCourseViewModel();
    }
}
