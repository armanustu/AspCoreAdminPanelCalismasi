using DataAcessLayer.Abstract;
using DataAcessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Repository
{
    public class RepositoryBase<Tentity> : IRepositoryBase<Tentity> where Tentity : class
    {
        public void Add(Tentity tentity)
        {
            using (var c = new Context())
            {
                c.Add(tentity);
                c.SaveChanges();
            }
        }
        public bool Delete(Tentity tentity)
        {

            bool durum = false;
            using (var context = new Context())
            {
                context.Update(tentity);

                if (context.SaveChanges() > 0)
                {
                    durum = true;
                }
            }
            return durum;
        }
        public List<Tentity> GetAll()
        {
            using var c = new Context();
            return c.Set<Tentity>().ToList();
        }
        public bool Update(Tentity tentity)
        {
            bool durum = false;
            using (var context = new Context())
            {
                context.Update(tentity);

                if (context.SaveChanges()>0)
                {
                    durum = true;
                }
            }
            return durum;
        }
        public List<Tentity> List(Expression<Func<Tentity, bool>> filter)
        {
            using (var c = new Context())
            {
                return c.Set<Tentity>().Where(filter).ToList();
            }
        }
        public Tentity BlogGetByID(int id)
        {
            using (var c = new Context())
            {
                return c.Set<Tentity>().Find(id);
            }
        }

        public Tentity GetByID(int id)
        {
            using (var c = new Context())
            {
                return c.Set<Tentity>().Find(id);
            }
        }
    }
}
