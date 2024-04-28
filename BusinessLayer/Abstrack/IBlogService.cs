using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static DataAcceessLayer.Concrete.BlogRepository;

namespace BusinessLayer.Abstrack
{
    public interface IBlogService
    {
        List<Blog> List();
        List<Blog> GetListWithCategoryByWriter(int id);

        Blog GetBlogByİD(int id);

        Blog GetBlogsWhit(int id);
        Blog AddBlog(Blog blog);


        void Delete(int id);
        List<Blog> GetListWithAuthor();
        List<Blog> GetListWithWriter(int authorId);
        Blog Update(Blog blog);

        List<BlogWithAuthors> GetBlogWithAuthors(int? pageNumber);
    }
}
