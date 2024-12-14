using BusinessLayer.Abstract;
using DataAcessLayer.Abstract;
using DataEntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {

        ICategoryDAL _categoryDAL;
        public CategoryManager(ICategoryDAL categoryDAL) {
            _categoryDAL = categoryDAL;
        }    
        public void CategoryAdd(Category category)
        {
            _categoryDAL.Add(category);
        }

        public bool CategoryDelete(Category category)
        {
            bool durum = false;
            category.CategoryStatus = false;
            durum = _categoryDAL.Delete(category);            
            return durum;
        }

        public bool CategoryUpdate(Category category)
        { 
            return _categoryDAL.Update(category);
        }

        public Category GetCategory(int id)
        {
          var result= _categoryDAL.GetByID(id);
            return result;
           
        }

        public List<Category> GetList()
        {
          return  _categoryDAL.GetAll();
        }

       
    }
}
