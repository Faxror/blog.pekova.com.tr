﻿using DataAcceessLayer.Abstrack;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcceessLayer.Concrete
{
    public class BlogRepository : IBlogRepository
    {
        private readonly Context _context;

        public BlogRepository(Context context)
        {
            _context = context;
        }

        public Blog GetBlogByİD(int id)
        {
            return _context.Blogs.Find(id);
        }

        public Blog GetBlogsWhit(int id)
        {
            var blogs = _context.Blogs.Join(
                _context.Authors.AsNoTracking(),
                blog => blog.AuthorID,
                author => author.AuthorID,
                (blog,author) => new { Author = author, Blog = blog }

                )
                .Join(
                 _context.Categories.AsNoTracking(),
                 blogWithAuthor => blogWithAuthor.Blog.CategoryID,
                 category => category.CategoryID,
                 (blogWithAuthor, category) => new { Author = blogWithAuthor.Author, Blog = blogWithAuthor.Blog, Category = category })
                .FirstOrDefault(b => b.Blog.BlogID == id);
            if (blogs != null)
            {
                Blog blog = new Blog()
                {
                    Author = blogs.Author,
                    AuthorID = blogs.Author.AuthorID,
                    BlogContent = blogs.Blog.BlogContent,
                    BlogID = blogs.Blog.BlogID,
                    BlogImage = blogs.Blog.BlogImage,   
                    BlogTime = blogs.Blog.BlogTime,
                    BlogTıtle = blogs.Blog.BlogTıtle,
                    Category = blogs.Category,
                    CategoryID = blogs.Blog.CategoryID
                };
                return blog;
            }
            return null;
        }

        public List<BlogWithAuthors> GetBlogWithAuthors(int? pageNumber)
        {
            int page = pageNumber ?? 1;
            int pageSize = 3;
            int offset = (page - 1) * pageSize;

            var blogs = _context.Blogs
                         .OrderBy(b => b.BlogID)
                         .Skip(offset)
                         .Take(pageSize)
                         .Join(_context.Authors.AsNoTracking(),
                               blog => blog.AuthorID,
                               author => author.AuthorID,
                               (blog, author) => new { Blog = blog, Author = author })
                         .Join(_context.Categories.AsNoTracking(),
                               temp => temp.Blog.CategoryID,
                               category => category.CategoryID,
                               (temp, category) => new BlogWithAuthors
                               {
                                   Blog = temp.Blog,
                                   Author = temp.Author,
                                   Category = category
                               })
                         .ToList();

            return blogs;
        }


        public class BlogWithAuthors
        {

            public Blog Blog { get; set; }
            public Author Author { get; set; }

            public Category Category { get; set; }
        }
        public List<Blog> GetListWithAuthor()
        {
            return _context.Blogs.Include(b => b.Author).Include(x => x.Category).ToList();
        }

        public List<Blog> List()
        {
           return _context.Blogs.ToList();
        }
    }
}
