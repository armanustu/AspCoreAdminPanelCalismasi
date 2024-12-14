using DataEntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IWriterService
    {
        void WriterAdd(Writer writer);
        void WriterDelete(Writer writer);
        bool WriterUpdate(Writer writer);
        List<Writer> GetList();
        Writer BlogGetByID(int id);
    }
}
