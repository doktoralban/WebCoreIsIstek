using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebCoreIsIstek.Models
{
    public partial class TbUserPhoto
    {
        [Key]
        [StringLength(50, ErrorMessage = "Kullanıcı Adı, uzunluğu {2} ve {1} arasında olmalıdır", MinimumLength = 3)]        
        [Required(AllowEmptyStrings =false,ErrorMessage = "Kullanıcı adı Gereklidir")]
        public string UserName { get; set; }
        public byte[] UserPhoto { get; set; }
    }
}
