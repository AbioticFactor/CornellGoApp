﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MobileApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string username;
        private string password;
        private string badText;

        public string Username { get => username; set => SetProperty(ref username, value); }
        public string Password { get => password; set => SetProperty(ref password, value); }
        public string BadText { get => badText; set => SetProperty(ref badText, value); }
        public Command LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(async () =>
            {
                await NavigationService.ToGamePage();
            });
        }
    }
}
