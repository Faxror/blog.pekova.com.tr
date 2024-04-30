using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcceessLayer.Abstrack
{
    public interface ICategoryRepository 
    {
        List<Category> GetList();
        Category GetListByID(int id);

        Category CategoryGetName(string categorynames);

        Category EditCategory(Category category);
        Category AddCategory(Category category);
        void DeleteCategory(int id);
    }
}
