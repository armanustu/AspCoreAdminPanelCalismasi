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
    public class CommentManager : ICommentService
    {
        ICommentDAL _commentDAL;
        public CommentManager(ICommentDAL commentDAL)
        {
            _commentDAL = commentDAL;
        }
        public void CommentAdd(Comment comment)
        {
            _commentDAL.Add(comment);
        }

        public void CommentDelete(Comment comment)
        {
           _commentDAL.Delete(comment);
        }

        public void CommentUpdate(Comment comment)
        {
          _commentDAL.Update(comment);
        }

        public List<Comment> GetByID(int id)
        {
            return _commentDAL.List(x => x.BlogID == id);
        }

		public List<Comment> GetList()
		{
            return _commentDAL.GetAll();
		}
	}
}
