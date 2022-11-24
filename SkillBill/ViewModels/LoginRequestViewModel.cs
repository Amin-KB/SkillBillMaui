using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MvvmHelpers;
using Newtonsoft.Json;
using SkillBill.Controls;
using SkillBill.Models;
using SkillBill.Services;
using SkillBill.ViewModels;
using SkillBill.Views;
using SkillBill.Views.Dashboards;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillBill.ViewModels
{
    public partial class LoginRequestViewModel:BaseViewModel
    {
        [ObservableProperty]
        private string _email;
        [ObservableProperty]
        public string _password;

        readonly ILoginService _loginService;
        public LoginRequestViewModel(ILoginService loginService)
        {
            _loginService=loginService; 
        }
        [RelayCommand]
        private async Task Login()
        {
          
            if (!string.IsNullOrWhiteSpace(Email)&& !string.IsNullOrWhiteSpace(Password))
            {
                //Calling API
               var response= await _loginService.Authenticate(new LogInRequest
                {
                    Email = Email,
                    Password = Password
                    
                });
                if(response != null)
                {
                    response.User.Email = Email;
                    Debug.WriteLine(App.UserInfo);
                    if (Preferences.ContainsKey(nameof(App.UserInfo)))
                    {
                        Preferences.Remove(nameof(App.UserInfo));
                    };
                   //stores the jwt Token in SecureStorage
                   await SecureStorage.SetAsync(nameof(App.Token), response.Token);
                    string userDetail = JsonConvert.SerializeObject(response.User);
                    Preferences.Set(nameof(App.UserInfo), userDetail);                 
                    App.UserInfo = response.User;
                    //if the User Athenticated then it goes to AddFlyOutMenuAsync()
                    await AppConstant.AddFlyOutMenuAsync();
                }
                else
                {
                    await AppShell.Current.DisplayAlert("Invalid Email or Password", "Invalid Email or Password", "OK");
                }

            }
        }       
    }
}
