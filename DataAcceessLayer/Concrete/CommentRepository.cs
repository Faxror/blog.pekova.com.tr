using DataAcceessLayer.Abstrack;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcceessLayer.Concrete
{
    public class CommentRepository : ICommentRepository
    {
        private readonly Context _context;

        public CommentRepository(Context context)
        {
            _context = context;
        }

        public Comment AddComment(Comment comment)
        {
            _context.Comments.Add(comment);
            _context.SaveChanges();
            return comment;
        }

        public void DeleteContact(int id)
        {
            var deletecontact = GetContactByİD(id);
            _context.Contacts.Remove(deletecontact);
            _context.SaveChanges();
        }

        public Contact GetContact(int id)
        {
            return _context.Contacts.FirstOrDefault(x => x.ContactID == id);
        }

        public Contact GetContactByİD(int id)
        {
            return _context.Contacts.Find(id);
        }

        public List<Comment> GetList()
        {
           return _context.Comments.ToList();
        }

        public List<Comment> GetListByBlog(int id)
        {
            return _context.Comments.Where(x => x.BlogID == id).ToList();
        }

        public Comment UpdateComment(Comment comment)
        {
            _context.Comments.Update(comment);
            _context.SaveChanges();
            return comment;
        }
    }
}
