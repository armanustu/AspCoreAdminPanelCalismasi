using DataEntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService
    {
        void CategoryAdd(Category category);
        bool CategoryDelete(Category category);
        bool CategoryUpdate(Category category);
        List<Category> GetList();
        Category GetCategory(int id);

    }
}
