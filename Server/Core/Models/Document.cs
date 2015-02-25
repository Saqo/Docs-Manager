using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Document
    {
        public Document() { }
        public Int64 Id { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public Guid RegistrationUserId { get; set; }
        public RegistrationUser RegistrationUser { get; set; }

    }
}
