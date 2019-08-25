using CRUD.Models.EntityModel.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD.Results.Persons
{
    public class PersonJson : ActionResult
    {
        public PersonJson() { }

        public PersonJson(Person person)
        {
            Name = person.Name;
            BirthDate = person.BirthDate;
            TaxDocument = person.TaxDocument;
            Email = person.Email;
            Mobile = person.Mobile;
        }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public string TaxDocument { get; set; }

        public string Email { get; set; }

        public string Mobile { get; set; }

        public override void ExecuteResult(ControllerContext context)
        {
            var json = new JsonResult();
            json.ExecuteResult(context);
        }
    }
}