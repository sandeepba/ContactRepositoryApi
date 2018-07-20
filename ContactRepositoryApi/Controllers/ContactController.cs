using ContactRepositoryApi.BL;
using ContactRepositoryApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web.Http;
using System.Web.Http.Description;

namespace RepositoryAPI.Controllers
{
    public class ContactController : ApiController
    {
        private ContactRepository _repository;
        public ContactController()
        {
            _repository = new ContactRepository();
        }
        
        [HttpGet]
        public IEnumerable<Contact> GetAllContacts()
        {
            IEnumerable<Contact> lstContact = null;
            ContactResponse response = new ContactResponse();
            response.contracts = _repository.GetAll().ToList();
            lstContact= response.contracts;
            return lstContact;
        }

        [HttpPost]
        public IHttpActionResult AddContact(Contact item)
        {
            if (_repository.Add(item))
            {
                return Ok();
            }
            else
            {
                return InternalServerError();
            }
        }

        [HttpPut]
        public IHttpActionResult UpdateContact(Contact item)
        {
            if (_repository.Update(item))
            {
                return Ok();
            }
            else
            {
                return InternalServerError();
            }
            
        }

        [HttpDelete]
        public IHttpActionResult RemoveContact(int ID)
        {
            try
            {
                _repository.Remove(ID);
                return Ok();
            }
            catch
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        [ResponseType(typeof(Contact))]
        public IHttpActionResult GetContactByID(int ID)
        {
            Contact contact= _repository.Get(ID);
            if(contact==new Contact() || contact==null)
            {
                return NotFound();
            }
            else
            {
                return Ok(contact);
            }
       }
    }
}