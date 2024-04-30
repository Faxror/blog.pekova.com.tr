using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class AppUser : IdentityUser<int>
    {
        public string NameAndSunName { get; set; }
        public string Phone { get; set; }
        public string Image { get; set; }
        public string About { get; set; }
        public string ShortAbout { get; set; }

        public int ConfirimCode { get; set; }


        public int AuthorID { get; set; }
        public virtual Author Author { get; set; }


    }
}
