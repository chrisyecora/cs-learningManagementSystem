﻿namespace MAUI.LMSystem.Views;
using Library.LMSystem.Services;
using MAUI.LMSystem.ViewModels;
public partial class ViewPersonsPage : ContentPage
{
    public ViewPersonsPage()
    {
        InitializeComponent();
        BindingContext = new ViewPersonsViewModel();
    }
}
