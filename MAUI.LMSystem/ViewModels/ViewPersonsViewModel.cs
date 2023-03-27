using System;
namespace MAUI.LMSystem.ViewModels
{
    public class ViewPersonsViewModel
    {
        public ViewPersonsViewModel()
        {
        }

        public Task Back() => Shell.Current.GoToAsync("..");
    }
}

