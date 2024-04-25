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

        Blog GetBlogByİD(int id);

        Blog GetBlogsWhit(int id);

        List<Blog> GetListWithAuthor();

        List<BlogWithAuthors> GetBlogWithAuthors(int? pageNumber);
    }
}
