using SkillBill.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillBill.Services
{
   public interface ILoginService
    {
        public Task<LogInResponse> Authenticate(LogInRequest logInRequest);
    }
}
