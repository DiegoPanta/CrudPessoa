using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace CRUD.Models.EntityModel.Persons
{
    public class PersonMap : EntityTypeConfiguration<Person>
    {
        public PersonMap()
        {
            ToTable("Pessoa", "dbo");
            HasKey(p => p.Id);

            Property(a => a.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.Name).HasColumnName("Nome").HasMaxLength(200).IsRequired();
            Property(p => p.BirthDate).HasColumnName("DataNascimento").IsRequired();
            Property(p => p.TaxDocument).HasColumnName("Cpf").HasMaxLength(14).IsRequired();
            Property(p => p.Email).HasColumnName("Email").HasMaxLength(45);
            Property(p => p.Mobile).HasColumnName("Celular").HasMaxLength(20);
        }
    }
}