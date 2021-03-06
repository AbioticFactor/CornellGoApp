﻿using MobileApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            RegistrationViewModel viewModel = (RegistrationViewModel)BindingContext;
            viewModel.Username = "";
            viewModel.Password = "";
            viewModel.PasswordVerification = "";
            viewModel.Email = "";
            viewModel.EmailVerification = "";
        }

        protected override bool OnBackButtonPressed()
        {
            return ((BaseViewModel)BindingContext).IsBusy ? true : base.OnBackButtonPressed();
        }
    }
}