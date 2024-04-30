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
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Category EditCategory(Category category)
        {
            return _categoryRepository.EditCategory(category);
        }

        public Category CategoryGetName(string categorynames)
        {
            return _categoryRepository.CategoryGetName(categorynames);
        }

        public void DeleteCategory(int id)
        {
             _categoryRepository.DeleteCategory(id);
        }

        public List<Category> GetList()
        {
          return _categoryRepository.GetList();
        }

        public Category GetListByID(int id)
        {
           return _categoryRepository.GetListByID(id);
        }

        public Category AddCategory(Category category)
        {
            return _categoryRepository.AddCategory(category);
        }
    }
}
