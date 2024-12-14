using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntityLayer.Concrete
{
    public class UserSignUp
    {
        [DisplayName("Adınız Soyadınız")]
        [Required(ErrorMessage ="Adı Soyad Zorunlu")]
        public string nameSurname { get; set; }
        [Required(ErrorMessage = "Lütfen şifre giriniz")]
        [DisplayName("Şifre Griniz")]
        public string Password { get; set; }

        //[DisplayName("tekrar şifre giriniz")]
        //[Compare("Password",ErrorMessage ="Şifreler Uyuşmuyor")]
        //public string confirmPassword { get; set; }
        [DisplayName("Mail adresiniz giriniz")]
        [Required(ErrorMessage = "mail adresi zorunlu")]
        public string Mail { get; set; }

        [DisplayName("Kullanıcı Adınızı giriniz")]
        [Required(ErrorMessage = "Kullanıcı adı zorunlu")]
        public string UserName { get; set; }
       
    }
}
