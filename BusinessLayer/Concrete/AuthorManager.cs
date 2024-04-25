using BusinessLayer.Abstrack;
using DataAcceessLayer.Abstrack;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AuthorManager : IAuthorService
    {
        private readonly IAuthorRepository authorRepository;

        public AuthorManager(IAuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;
        }

        public Author AddAuthor(Author author)
        {
            return authorRepository.AddAuthor(author);
        }

        public List<Author> GetList()
        {
            return authorRepository.GetList();
        }

        public Author UpdateAuthor(Author author)
        {
            return authorRepository.UpdateAuthor(author);
        }
    }
}
