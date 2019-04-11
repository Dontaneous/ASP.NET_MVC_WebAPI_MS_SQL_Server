using DataAccessLibrary.Logic;
using HireDanteJones.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace HireDanteJones.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "A liitle bit about myself.";

            return View();
        }

        public ActionResult ContactDante()
        {
            ViewBag.Message = "My contact info.";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ContactDante(ContactModel model)
        {
            if (ModelState.IsValid)
            {
                int recorded = ContactProcessor.CreateContact(model.FirstName, model.LastName, model.PhoneNumber, model.EmailAddress);
                return RedirectToAction("ViewContacts");
            }

            return View();
        }

        public ActionResult ViewContacts()
        {
            ViewBag.Message = "People on my contact list from my Database.";

            var data = ContactProcessor.LoadContacts();
            List<ContactModel> contacts = new List<ContactModel>();

            foreach(var row in data)
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

            return View(contacts);
        }

        public ActionResult Edit(int id)
        {
            var data = ContactProcessor.LoadContacts();
            
            foreach (var row in data)
            {
                if(id == row.Id)
                {
                    ContactModel contact = new ContactModel
                    {
                        Id = row.Id,
                        FirstName = row.FirstName,
                        LastName = row.LastName,
                        PhoneNumber = row.PhoneNumber,
                        EmailAddress = row.EmailAddress
                    };
                    return View(contact);
                }
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ContactModel model)
        {
            if (ModelState.IsValid)
            {
                ContactProcessor.UpdateContact(model.Id, model.FirstName, model.LastName, model.PhoneNumber, model.EmailAddress);
                return RedirectToAction("ViewContacts");
            }
            return View();
        }

        public ActionResult Details(int id)
        {
            ViewBag.Message = "Contact Detail";

            var data = ContactProcessor.LoadContacts();

            foreach (var row in data)
            {
                if (id == row.Id)
                {
                    ContactModel contact = new ContactModel
                    {
                        Id = row.Id,
                        FirstName = row.FirstName,
                        LastName = row.LastName,
                        PhoneNumber = row.PhoneNumber,
                        EmailAddress = row.EmailAddress
                    };
                    return View(contact);
                }
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            ViewBag.Message = "Are you sure";

            var data = ContactProcessor.LoadContacts();

            foreach (var row in data)
            {
                if (id == row.Id)
                {
                    ContactModel contact = new ContactModel
                    {
                        Id = row.Id,
                        FirstName = row.FirstName,
                        LastName = row.LastName,
                        PhoneNumber = row.PhoneNumber,
                        EmailAddress = row.EmailAddress
                    };
                    return View(contact);
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult Delete(ContactModel model)
        {
            ContactProcessor.DeleteContact(model.Id);
            return RedirectToAction("ViewContacts");
        }
    }
}