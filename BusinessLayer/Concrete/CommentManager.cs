using BusinessLayer.Abstrack;
using DataAcceessLayer.Abstrack;
using EntityLayer.Concrete;
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

        public CommentManager(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public Comment AddComment(Comment comment)
        {
           return _commentRepository.AddComment(comment);
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
