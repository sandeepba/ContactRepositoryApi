using ContactRepositoryApi.DAL;
using ContactRepositoryApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactRepositoryApi.BL
{
    public class ContactRepository : IContactRepository
    {
        private ContactEngine _engine;

        public ContactRepository()
        {
            _engine = new ContactEngine();
        }

        public bool Add(Contact item)
        {
          return _engine.AddContact(item);
        }

        public Contact Get(int id)
        {
          return _engine.GetContactByID(id);
        }

        public IEnumerable<Contact> GetAll()
        {
           return _engine.GetAllContacts();
        }

        public void Remove(int id)
        {
           _engine.RemoveContact(id);
        }

        public bool Update(Contact item)
        {
           return _engine.UpdateContact(item);
        }
    }
}