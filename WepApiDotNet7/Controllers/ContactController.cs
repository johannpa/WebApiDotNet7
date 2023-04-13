using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WepApiDotNet7.Models;

namespace WepApiDotNet7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        static public List<Contact> Contacts = new List<Contact>
        {
            new Contact { Id = 1, Name = "Bruce Wayne", BirthDate = new DateTime(1915, 4, 17)},
            new Contact { Id = 2, Name = "Peter Parker", BirthDate = new DateTime (2001, 8, 10)}
        };

        [HttpGet]
        public ActionResult<List<Contact>> GetAllContacts()
        {
            return Ok(Contacts);
        }

        [HttpGet("{id}")]
        public ActionResult<Contact> GetContact(int id)
        {
            var contact = Contacts.Find(x => x.Id == id); // To find with id
            //var contact = Contacts[id]; // To find with the place 
            if(contact == null)
            {
                return NotFound("Nope.");
            }
            return Ok(contact);
        }

        [HttpPost]
        public ActionResult<List<Contact>> CreateContact(Contact contact)
        {
            Contacts.Add(contact);
            return Ok(Contacts);
        }

        [HttpPut]
        public ActionResult<List<Contact>> UpdateContact(Contact updatedContact)
        {
            var contact = Contacts.Find(x => x.Id == updatedContact.Id);
            if (contact == null)
            {
                return NotFound("Nope.");
            }

            contact.Name = updatedContact.Name;
            contact.BirthDate = updatedContact.BirthDate;

            return Ok(Contacts);
        }

        [HttpDelete("{id}")]
        public ActionResult<List<Contact>> Delete(int id)
        {
            var contact = Contacts.Find(x => x.Id == id);
            if (contact == null)
            {
                return NotFound("Nope.");
            }

            Contacts.Remove(contact);

            return Ok(Contacts);
        }
    }
}
