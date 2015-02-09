﻿using Nancy.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Models
{
    [PetaPoco.TableName("Users")]
    [PetaPoco.PrimaryKey("Id")]
    public class User : IUserIdentity
    {
        public Guid Id { get; set; }
        public IEnumerable<string> Claims { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
    }
}
