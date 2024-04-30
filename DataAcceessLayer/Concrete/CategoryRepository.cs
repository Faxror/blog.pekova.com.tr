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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Context _context;

        public CategoryRepository(Context context)
        {
            _context = context;
        }

        public Category EditCategory(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
            return category;
        }

        public Category CategoryGetName(string categorynames)
        {
            return _context.Categories.FirstOrDefault(c => c.CategoryName == categorynames);
        }

        public void DeleteCategory(int id)
        {
            var deletecategory = GetListByID(id);
            _context.Categories.Remove(deletecategory);
            _context.SaveChanges();

        }

        public List<Category> GetList()
        {
            return _context.Categories.ToList();
        }

        public Category GetListByID(int id)
        {
            return _context.Categories.Find(id);
        }

        public Category AddCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return category;
        }
    }
}
