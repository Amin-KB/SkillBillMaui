using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillBill.Models
{
    public class LogInResponse
    {
        public string Token { get; set; }
        public UserDisplayInfo User { get; set; }
    }
}
