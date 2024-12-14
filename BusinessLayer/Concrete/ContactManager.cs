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
    public class ContactManager : IContactService
    {
        IContactDAL _contactDAL;
        public ContactManager(IContactDAL contactDAL)
        {
            _contactDAL = contactDAL;
        }
        public void ContactAdd(Contact contact)
        {
            _contactDAL.Add(contact);
        }

        public void ContactDelete(Contact contact)
        {
           _contactDAL.Delete(contact);
        }

        public void ContactUpdate(Contact contact)
        {
           _contactDAL.Update(contact);
        }

        public List<Contact> GetList()
        {
            return _contactDAL.GetAll();
        }
    }
}
