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
    public class AboutManager : IAboutService
    {
        IAboutDAL aboutdal;
        public AboutManager(IAboutDAL _aboutdal)
        {
                aboutdal=_aboutdal;
        }

        public void AboutAdd(About about)
        {
           aboutdal.Add(about);
        }

        public void AboutDelete(About about)
        {
            aboutdal.Delete(about);
        }

        public void AboutUpdate(About about)
        {
            aboutdal.Delete(about);
        }

        public List<About> GetList()
        {
            return aboutdal.GetAll();
        }
    }
}
