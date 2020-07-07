using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebCoreIsIstek.Models
{
    public class UserViewModel
    {
        [Key]
        public int UserID { get; set; }
        public string UserLoginName { get; set; }
        public string UserNameSurName { get; set; }
        public List<string> UserRoles { get; set; }        
        public string UserEmail { get; set; }
        public byte[] UserPhoto { get; set; }
        public bool UserActive { get; set; }

    }
}
