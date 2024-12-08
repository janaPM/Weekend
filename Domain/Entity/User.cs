using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class User
    {
        public string id { get;  set; } 
        public string? name { get; set; }
        public string? bio { get; set; }
        public string? work { get; set; }
        public string? education { get; set; }
        public string? gender { get; set; }
        public string? location { get; set; }
        public string? hometown { get; set; }
        public string? height { get; set; }
        public string? exercise { get; set; }
        public string? educationlevel { get; set; }
        public string? interest { get; set; }
    }
}
