using BusinessLayer.Abstrack;
using DataAcceessLayer.Abstrack;
using DataAcceessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly Context context;

        public CommentManager(ICommentRepository commentRepository, Context context)
        {
            _commentRepository = commentRepository;
            this.context = context;
        }

        public Comment AddComment(Comment comment)
        {
           return _commentRepository.AddComment(comment);
        }

        public void DeleteContact(int id)
        {
            _commentRepository.DeleteContact(id);
        }

        public Contact GetContact(int id)
        {
           return _commentRepository.GetContact(id);
        }

        public Contact GetContactByİD(int id)
        {
            return _commentRepository.GetContactByİD(id);
        }

        public List<Comment> GetList()
        {
           return _commentRepository.GetList();
        }

        public List<Comment> GetListByBlog(int id)
        {
            return _commentRepository.GetListByBlog(id);
        }

        public Comment UpdateComment(Comment comment)
        {
           return _commentRepository.UpdateComment(comment);
        }
    }
}
