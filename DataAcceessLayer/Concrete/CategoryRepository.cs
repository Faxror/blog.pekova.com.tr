using DataAcceessLayer.Abstrack;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcceessLayer.Concrete
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Context _context;

        public CategoryRepository(Context context)
        {
            _context = context;
        }

        public Category CategoryGetName(string categorynames)
        {
            return _context.Categories.FirstOrDefault(c => c.CategoryName == categorynames);
        }

        public List<Category> GetList()
        {
            return _context.Categories.ToList();
        }
    }
}
