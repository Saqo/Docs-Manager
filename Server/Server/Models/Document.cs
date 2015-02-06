using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Models
{
    [PetaPoco.TableName("Documents")]
    [PetaPoco.PrimaryKey("Id")]
    public class Document
    {
        public Guid Id { get; set; }
        public String Title { get; set; }
    }
}
