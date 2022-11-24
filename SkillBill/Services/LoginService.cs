
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SkillBill.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace SkillBill.Services
{
    public class LoginService : ILoginService
    {
        public async Task<LogInResponse> Authenticate(LogInRequest logInRequest)
        {
            //we can not use Localhost because Emulator cannt use it so instead of localhost we must use this IP: 10.0.2.2
            //During development we can not use https due to ssl 
            string BaseAddress =
        DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5001" : "http://localhost:5001";
            string url = $"{BaseAddress}/api/LogIn/authenticate";
          
            using (var httpClient= new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string loginRequest=JsonConvert.SerializeObject(logInRequest);
                 
                var response=await httpClient.PostAsync(url,
                    new StringContent(loginRequest,Encoding.UTF8,"application/json"));  
                if(response.StatusCode==System.Net.HttpStatusCode.OK) 
                {
                    var json =await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<LogInResponse>(json);
                }
                else
                    return null;
            }   
			
        }
      
    }
}
