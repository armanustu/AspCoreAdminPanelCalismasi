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
    public class AdminManager : IAdminService
    {
        IAdminDal _AdminDal;
        public AdminManager(IAdminDal _adminDal) {

            _AdminDal = _adminDal;
        
        }   
        public List<Admin> GetList()
        {
          return _AdminDal.GetAll();
        }
    }
}
