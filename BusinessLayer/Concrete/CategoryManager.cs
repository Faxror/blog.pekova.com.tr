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

        public Category CategoryGetName(string categorynames)
        {
            return _categoryRepository.CategoryGetName(categorynames);
        }

        public List<Category> GetList()
        {
            return _categoryRepository.GetList();
        }
    }
}
