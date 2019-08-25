using CRUD.Models.EntityModel.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD.Results.Persons
{
    public class PersonListJson : ActionResult
    {
        public PersonListJson() { }

        public PersonListJson(ICollection<Person> persons, long count)
        {
            Persons = persons.Select(person => new PersonJson(person)).ToList();
            Count = count;
        }

        public ICollection<PersonJson> Persons { get; set; }
        public long Count { get; set; }

        public override void ExecuteResult(ControllerContext context)
        {
            var json = new JsonResult();
            json.ExecuteResult(context);
        }
    }
}