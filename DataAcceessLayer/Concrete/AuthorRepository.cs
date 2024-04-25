using DataAcceessLayer.Abstrack;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DataAcceessLayer.Concrete
{
    public class AuthorRepository : IAuthorRepository
    {
        public readonly Context _context;

        public AuthorRepository(Context context)
        {
            _context = context;
        }

        public Author AddAuthor(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
            return author;
        }

        public List<Author> GetList()
        {
            return _context.Authors.ToList();
        }

        public Author UpdateAuthor(Author author)
        {
            _context.Authors.Update(author);
            _context.SaveChanges();
            return author;
        }
    }
}
