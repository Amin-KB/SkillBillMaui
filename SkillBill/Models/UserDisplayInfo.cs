using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillBill.Models
{
   public class UserDisplayInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string userName { get; set; }

        public int Role { get; set; }
        public string RoleText { get; set; }
    }
    public enum Role
    {
        Admin=1,
        RehaCoach,
        Trainer,
        Kunde
    }
}
