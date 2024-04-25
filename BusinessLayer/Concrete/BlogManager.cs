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
    public class BlogManager : IBlogService
    {
        private readonly IBlogRepository blogRepository;

        public BlogManager(IBlogRepository blogRepository)
        {
            this.blogRepository = blogRepository;
        }

        public Blog AddBlog(Blog blog)
        {
           return blogRepository.AddBlog(blog);
        }

        public Blog GetBlogByİD(int id)
        {
            return blogRepository.GetBlogByİD(id);
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



        public void Delete(int id)
        {
            blogRepository.Delete(id);
        }
        List<BlogRepository.BlogWithAuthors> IBlogService.GetBlogWithAuthors(int? pageNumber)
        {
            var b = blogRepository.GetBlogWithAuthors(pageNumber);
            return b;
        }

        public Blog Update(Blog blog)
        {
            return blogRepository.Update(blog);
        }
    }
}
