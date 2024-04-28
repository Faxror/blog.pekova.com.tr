﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Author
    {
        public int AuthorID { get; set; }
        public string AuthorName { get; set; }
        public string AuthorImage { get; set; }

        public string Mail { get; set; }
       

        public string AuthorAbout { get; set; }

        public string Phone {  get; set; }
        public string ShortAbout {  get; set; }

        public ICollection<Blog> Blogs { get; set; }
        public ICollection<AppUser> AppUsers { get; set; }
    }
}
