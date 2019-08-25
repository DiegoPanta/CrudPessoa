﻿using CRUD.Models.EntityModel.Persons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.ViewModel.Persons
{
    public class PersonModel
    {
        [Display(Name = "name")]
        public string Name { get; set; }

        [Display(Name = "birthDate")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "taxDocument")]
        public string TaxDocument { get; set; }

        [Display(Name = "email")]
        public string Email { get; set; }

        [Display(Name = "mobile")]
        public string Mobile { get; set; }

        public Person Map() => new Person
        {
            Name = Name,
            BirthDate = BirthDate,
            TaxDocument = TaxDocument,
            Email = Email,
            Mobile = Mobile
        };
    }
}