using DataAcessLayer.Concrete;
using DataEntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Abstract
{
    public interface IBlogDAL:IRepositoryBase<Blog>
    {

        public List<Blog> GetListBlogWithCategory()
        {
            using (Context context = new Context())
            {
                return context.Blogs.Include(x => x.Category).ToList();
            }
        }
		public List<Blog> GetListBlogWithCategoryWithID(int id)
		{
			using (Context context = new Context())
			{
				return context.Blogs.Include(x => x.Category).Where(x=>x.WriterID==id).ToList();
			}
		}
	}
}
