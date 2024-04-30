using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Comment
    {
        public int CommentID { get; set; }
        public string Username { get; set; }
        public string Mail { get; set; }
        public string Image { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentDate { get; set; }
        public int BlogID { get; set; }
        public virtual Blog Blog { get; set; }
    }
}
