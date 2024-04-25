using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstrack
{
    public interface IAuthorService
    {

        List<Author> GetList();

        Author AddAuthor(Author author);
        Author UpdateAuthor(Author author);
    }
}
