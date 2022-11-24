using CommunityToolkit.Mvvm.Input;
using SkillBill.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillBill.ViewModels
{
    public partial class AppShellViewModel : BaseViewModel
    {
        [RelayCommand]
        private async void Logout()
        {
            if (Preferences.ContainsKey(nameof(App.UserInfo)))
            {
                Preferences.Remove(nameof(App.UserInfo));
            };
            await Shell.Current.GoToAsync($"//{nameof(InternalLogInPage)}");
        }
    }
}
