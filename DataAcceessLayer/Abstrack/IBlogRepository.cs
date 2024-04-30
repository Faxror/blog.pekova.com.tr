using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
 
        List<Blog> GetBlogByAuthors(int id);
        List<Blog> GetListWithCategoryByWriter(int id);
        Blog AddBlog(Blog blog);

        void Delete(int id);
        Blog Update(Blog blog);
        List<Blog> GesList(Expression<Func<Blog, bool>> filter);
        List<BlogWithAuthors> GetBlogWithAuthors(int? pageNumber);
    }
}
