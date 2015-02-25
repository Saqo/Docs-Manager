using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Models
{
    public class RegistrationUser
    {
        public Guid Id { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }
        public Boolean IsAdmin { get; set; }

    }
}
