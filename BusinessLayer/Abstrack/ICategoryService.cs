using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstrack
{
    public interface ICategoryService
    {
        List<Category> GetList();

        Category CategoryGetName(string categorynames);
    }
}
