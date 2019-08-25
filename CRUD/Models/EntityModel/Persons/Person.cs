using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD.Models.EntityModel.Persons
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string TaxDocument { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
    }
}