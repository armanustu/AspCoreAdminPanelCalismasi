using DataEntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBlogService
    {
        void BlogAdd(Blog blog);
        bool BlogDelete(Blog blog);
        bool BlogUpdate(Blog blog);
        List<Blog> GetList();
        List<Blog>GetListBlogWithCategory();
        Blog BlogGetByID(int id);
        List<Blog> GetListBlogByWriter(int id);
        List<Blog> GetListBlogWithCategoryWithID(int id);

	}
}
