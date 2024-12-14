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
    public class BlogManager : IBlogService
    {
        public IBlogDAL _blogDAL;
        public BlogManager(IBlogDAL blogDAL)
        {
            _blogDAL = blogDAL;
        }
        public void BlogAdd(Blog blog)
        {
          _blogDAL.Add(blog);
        }

        public bool BlogDelete(Blog blog)
        {
          return _blogDAL.Delete(blog);   
        }

        public Blog BlogGetByID(int id)
        {
            return _blogDAL.BlogGetByID(id);
        }

        public bool BlogUpdate(Blog blog)
        {
          return _blogDAL.Update(blog);
        }

        public List<Blog> GetList()
        {
           return _blogDAL.GetAll();
        }

		public List<Blog> GetListBlogByWriter(int id)
		{
            return _blogDAL.List(x => x.WriterID == id);
		}

		public List<Blog> GetListBlogWithCategory()
        {
          return  _blogDAL.GetListBlogWithCategory();

        }

		public List<Blog> GetListBlogWithCategoryWithID(int id)
		{
           return _blogDAL.GetListBlogWithCategoryWithID(id);
		}
	}
}
