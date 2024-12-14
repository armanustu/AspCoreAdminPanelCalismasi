using DataEntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Abstract
{
    public interface IRepositoryBase<Tentity> where Tentity : class
    {
        List<Tentity> GetAll();
        Tentity BlogGetByID(int id);
        void Add(Tentity tentity);
        bool Delete(Tentity tentity);
        bool Update(Tentity tentity);
        List<Tentity> List(Expression<Func<Tentity, bool>> filter);
        Tentity GetByID(int id);

	}
}
