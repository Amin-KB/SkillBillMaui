using Newtonsoft.Json;
using SkillBill.Controls;
using SkillBill.Models;
using SkillBill.Views;
using SkillBill.Views.Dashboards;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillBill.ViewModels
{
    public partial class LoadingViewModel : BaseViewModel
    {
        public LoadingViewModel()
        {
            CheckingUserDetail();
        }
        async Task CheckingUserDetail()
        {
            
            var user = Preferences.Get(nameof(App.UserInfo), "");

            if (string.IsNullOrWhiteSpace(user))
            {
                await Shell.Current.GoToAsync($"//{nameof(InternalLogInPage)}");
        }

            else
            {
               
                var userToken = await SecureStorage.GetAsync(nameof(App.Token));
                var tokenHandler = new JwtSecurityTokenHandler();
              
                var jsonToken = tokenHandler.ReadToken(userToken) as JwtSecurityToken;
                if (jsonToken.ValidTo<DateTime.UtcNow)
                {
                    await Shell.Current.DisplayAlert("User session expired", "Login again to continue", "OK");
                    await Shell.Current.GoToAsync($"//{nameof(InternalLogInPage)}");
                }
           
                else
                {
                    var userDetails = JsonConvert.DeserializeObject<UserDisplayInfo>(user);
                    App.UserInfo = userDetails;
                    App.Token = userToken;
                    await AppConstant.AddFlyOutMenuAsync();
                }
            }
        }

        
   
    }
}
