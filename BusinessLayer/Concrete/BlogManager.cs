using BusinessLayer.Abstrack;
using DataAcceessLayer.Abstrack;
using DataAcceessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BlogManager : IBlogService
    {
        private readonly IBlogRepository blogRepository;

        public BlogManager(IBlogRepository blogRepository)
        {
            this.blogRepository = blogRepository;
        }

        public Blog GetBlogByİD(int id)
        {
            throw new NotImplementedException();
        }

        public Blog GetBlogsWhit(int id)
        {
            var blogs = blogRepository.GetBlogsWhit(id);
            return blogs;
        }

        public List<Blog> GetListWithAuthor()
        {
            return blogRepository.GetListWithAuthor();
        }

        public List<Blog> List()
        {
            return blogRepository.List();
        }

     

        List<BlogRepository.BlogWithAuthors> IBlogService.GetBlogWithAuthors(int? pageNumber)
        {
            var b = blogRepository.GetBlogWithAuthors(pageNumber);
            return b;
        }
    }
}
