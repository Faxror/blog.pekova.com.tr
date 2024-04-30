using BusinessLayer.Abstrack;
using DataAcceessLayer.Abstrack;
using DataAcceessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataAcceessLayer.Concrete.BlogRepository;

namespace BusinessLayer.Concrete
{
    public class BlogManager : IBlogService
    {
        private readonly IBlogRepository blogRepository;
        private readonly Context context;

        public BlogManager(IBlogRepository blogRepository, Context context)
        {
            this.blogRepository = blogRepository;
            this.context = context;
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
        public List<Blog> GetListWithWriter(int authorId)
        {
            return context.Blogs.Where(b => b.AuthorID == authorId).ToList();
        }

        public List<Blog> GetListWithCategoryByWriter(int id)
        {
            return blogRepository.GetListWithCategoryByWriter(id);
        }

        public List<Blog> GetBlogByAuthors(int id)
        {
           return blogRepository.GetBlogByAuthors(id);
        }

        public List<BlogWithAuthors2> GetBlogByCategory(int id)
        {
            var blogs = context.Blogs
                .Where(b => b.CategoryID == id) // Kategori ID'sine göre filtrele
                .OrderBy(b => b.BlogID)
                .Join(context.Authors.AsNoTracking(),
                      blog => blog.AuthorID,
                      author => author.AuthorID,
                      (blog, author) => new { Blog = blog, Author = author })
                .Join(context.Categories.AsNoTracking(),
                      temp => temp.Blog.CategoryID,
                      category => category.CategoryID,
                      (temp, category) => new BlogWithAuthors2
                      {
                          Blog = temp.Blog,
                          Author = temp.Author,
                          Category = category
                      })
                .ToList();

            return blogs;
        }


        public class BlogWithAuthors2
        {

            public Blog Blog { get; set; }
            public Author Author { get; set; }

            public Category Category { get; set; }
        }
    }
}
