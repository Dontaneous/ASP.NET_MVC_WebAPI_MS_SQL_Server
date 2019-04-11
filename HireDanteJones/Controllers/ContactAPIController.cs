using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccessLibrary.Logic;
using HireDanteJones.Models;

namespace HireDanteJones.Controllers
{
    public class ContactAPIController : ApiController
    {
        // GET api/ContactAPI
        public List<ContactModel> Get()
        {
            var data = ContactProcessor.LoadContacts();
            List<ContactModel> contacts = new List<ContactModel>();

            foreach (var row in data)
            {
                contacts.Add(new ContactModel
                {
                    Id = row.Id,
                    FirstName = row.FirstName,
                    LastName = row.LastName,
                    PhoneNumber = row.PhoneNumber,
                    EmailAddress = row.EmailAddress
                });
            }
            return contacts;
        }

        // GET api/<controller>/5
        public ContactModel Get(int id)
        {
            var data = ContactProcessor.LoadContacts();
            foreach(var row in data)
            {
                if(row.Id == id)
                {
                    ContactModel contact = new ContactModel
                    {
                        Id = row.Id,
                        FirstName = row.FirstName,
                        LastName = row.LastName,
                        PhoneNumber = row.PhoneNumber,
                        EmailAddress = row.EmailAddress
                    };

                    return contact;
                }
            }
            ContactModel temp = new ContactModel { };
            return temp;
        }

        // POST api/<controller>
        public void Post([FromBody] ContactModel model)
        {
            ContactProcessor.CreateContact(model.FirstName, model.LastName, model.PhoneNumber, model.EmailAddress);
        }

        // PUT api/<controller>/5
        public void Put(int id,[FromBody] ContactModel model)
        {
            ContactProcessor.UpdateContact(id, model.FirstName, model.LastName, model.PhoneNumber, model.EmailAddress);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            var data = ContactProcessor.LoadContacts();
            foreach (var row in data)
            {
                if (row.Id == id)
                {
                    ContactProcessor.DeleteContact(row.Id);
                }
            }
        }
    }
}