using MAUI.LMSystem.ViewModels;

namespace MAUI.LMSystem.Views;

public partial class BufferStudentView : ContentPage
{
    public BufferStudentView()
    {
        InitializeComponent();
        BindingContext = new BufferStudentViewModel();
    }
}
