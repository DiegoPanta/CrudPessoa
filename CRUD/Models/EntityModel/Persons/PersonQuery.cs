using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD.Models.EntityModel.Persons
{
    public static class PersonQuery
    {
        public static IQueryable<Person> WhereTaxDocument(this IQueryable<Person> persons, string taxDocument)
        {
            if (string.IsNullOrEmpty(taxDocument)) return persons;

            return persons.Where(person => person.TaxDocument == taxDocument);
        }

        public static IQueryable<Person> WhereId(this IQueryable<Person> persons, int id)
        {
            if (id == 0) return persons;

            return persons.Where(person => person.Id == id);
        }

        public static IQueryable<Person> OrderByName(this IQueryable<Person> persons)
        {
            return persons.OrderBy(person => person.Name);
        }
    }
}