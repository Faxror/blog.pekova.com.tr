using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcceessLayer.Abstrack
{
    public interface IAuthorRepository
    {
        List<Author> GetList();

        Author UpdateAuthor(Author author);

        Author AddAuthor(Author author);
    }
}
