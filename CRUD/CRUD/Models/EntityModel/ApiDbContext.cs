using CRUD.Models.EntityModel.Persons;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace CRUD.Models.EntityModel
{
    public class ApiDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }

        public ApiDbContext() : base("name=CrudDB")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new PersonMap());
        }
    }
}