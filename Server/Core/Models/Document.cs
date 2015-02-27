using System;

namespace Core.Models
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
