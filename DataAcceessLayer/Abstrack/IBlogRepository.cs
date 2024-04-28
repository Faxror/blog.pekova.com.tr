using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataAcceessLayer.Concrete.BlogRepository;

namespace DataAcceessLayer.Abstrack
{
    public interface IBlogRepository
    {
        List<Blog> List();
        //Blog GetListAll(int id);

        Blog GetBlogByİD(int  id);

        Blog GetBlogsWhit(int id);

        List<Blog> GetListWithAuthor();

        List<Blog> GetListWithCategoryByWriter(int id);
        Blog AddBlog(Blog blog);

        void Delete(int id);
        Blog Update(Blog blog);
        List<BlogWithAuthors> GetBlogWithAuthors(int? pageNumber);
    }
}
