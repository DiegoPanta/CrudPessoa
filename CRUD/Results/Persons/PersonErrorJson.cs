using CRUD.Models.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD.Results.Persons
{
    public class PersonErrorJson : ActionResult
    {
        private PersonManagement _personManagement;

        public PersonErrorJson(PersonManagement personManagement)
        {
            _personManagement = personManagement;

            if (_personManagement.PersonNotFound)
            {
                Error = "PERSON_NOT_FOUND";
            }
        }

        public string Error { get; set; }

        public override void ExecuteResult(ControllerContext context)
        {
            var json = new JsonResult();
            json.ExecuteResult(context);
        }
    }
}