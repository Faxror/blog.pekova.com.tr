using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace EntityLayer.Concrete
{
    public class Blog
    {
        public int BlogID { get; set; }
        public string BlogTıtle { get; set; }

        public string BlogImage { get; set; }
        public DateTime BlogTime { get; set; }


        public string BlogContent { get; set; }
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public int AuthorID { get; set; }
        public virtual Author Author { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
