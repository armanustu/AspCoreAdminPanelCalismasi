using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntityLayer.Concrete
{
    public class AppUser:IdentityUser<int>//identityfremworkcorepaket 6.0 ,identityFramework yükle
    {
        public string nameSurname { get; set; }
        public string imageUrl  { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
    }
}
