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
    public class WriterManager : IWriterService
    {
        IWriterDAL _writerDAL;
        public WriterManager(IWriterDAL writerDAL)
        {
                _writerDAL= writerDAL;
        }

        public Writer BlogGetByID(int id)
        {
            return _writerDAL.BlogGetByID(id);
        }

        public List<Writer> GetList()
        {
            return _writerDAL.GetAll();
        }

        public void WriterAdd(Writer writer)
        {
           _writerDAL.Add(writer);
        }

        public void WriterDelete(Writer writer)
        {
          _writerDAL.Delete(writer);  
        }

        public bool WriterUpdate(Writer writer)
        {
           return _writerDAL.Update(writer);    
        }
    }
}
