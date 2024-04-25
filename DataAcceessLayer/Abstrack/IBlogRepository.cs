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

        Blog GetBlogByİD(int  id);

        Blog GetBlogsWhit(int id);

        List<Blog> GetListWithAuthor();

        List<BlogWithAuthors> GetBlogWithAuthors(int? pageNumber);
    }
}
