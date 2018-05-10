using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EticaretV1.UI.Areas.Member.Models
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Kullanıcı Adı Boş Geçilemez!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Şifre Boş Geçilemez!")]
        public string Password { get; set; }
    }
}