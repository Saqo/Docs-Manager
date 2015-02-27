using System;
using System.Collections.Generic;

namespace Core.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public IEnumerable<string> Claims { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
    }
}
