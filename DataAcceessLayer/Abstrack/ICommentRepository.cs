using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcceessLayer.Abstrack
{
    public interface ICommentRepository
    {
        List<Comment> GetList();
        List<Comment> GetListByBlog(int id);

        Comment UpdateComment(Comment comment);

        Comment AddComment(Comment comment);

        Contact GetContact(int id);
        Contact GetContactByİD(int id);
        void DeleteContact(int id);
    }
}
