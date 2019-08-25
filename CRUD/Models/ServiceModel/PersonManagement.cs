using CRUD.Models.EntityModel;
using CRUD.Models.EntityModel.Persons;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CRUD.Models.ServiceModel
{
    public class PersonManagement
    {
        public PersonManagement() { }

        public Person Person { get; set; }
        public bool PersonNotFound { get; set; }

        public async Task Find(int id)
        {
            using (ApiDbContext dbContext = new ApiDbContext())
            {
                Person = await dbContext
                .Persons
                .WhereId(id)
                .SingleOrDefaultAsync();

                PersonNotFound = Person == null;
                if (PersonNotFound) return;
            }
        }

        public async Task<bool> Create(Person person)
        {
            using (ApiDbContext dbContext = new ApiDbContext())
            {
                Person = person;

                await CheckAlreadyExists(Person.TaxDocument);
                if (PersonNotFound) return false;

                dbContext.Persons.Add(Person);
                await dbContext.SaveChangesAsync();

                return true;
            }
        }

        public async Task<bool> Update()
        {
            using (ApiDbContext dbContext = new ApiDbContext())
            {
                PersonNotFound = Person == null;
                if (PersonNotFound) return false;

                await CheckAlreadyExists(Person.TaxDocument);
                if (PersonNotFound) return false;

                await dbContext.SaveChangesAsync();

                return true;
            }
        }

        public async Task<bool> Delete()
        {
            using (ApiDbContext dbContext = new ApiDbContext())
            {
                if (PersonNotFound) return false;

                //dbContext.Persons.Remove(Person);
                dbContext.Entry(Person).State = EntityState.Deleted;
                await dbContext.SaveChangesAsync();

                return true;
            }
        }

        private async Task CheckAlreadyExists(string taxDocument)
        {
            using (ApiDbContext dbContext = new ApiDbContext())
            {
                PersonNotFound = await dbContext
                .Persons
                .WhereTaxDocument(taxDocument)
                .AnyAsync();
            }
        }
    }
}