using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstrack
{
    public interface ICommentService
    {
        List<Comment> GetList();
        List<Comment> GetListByBlog(int id);

        Comment UpdateComment(Comment comment);

        Comment AddComment(Comment comment);
    }
}
