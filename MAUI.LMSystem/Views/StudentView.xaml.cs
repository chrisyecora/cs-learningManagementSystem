namespace MAUI.LMSystem.Views;

public partial class StudentView : ContentPage
{
    public StudentView()
    {
        InitializeComponent();
    }

    void BackClicked(System.Object sender, System.EventArgs e) {
        Shell.Current.GoToAsync("//MainPage");
    }
}
