
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ContactDAL.Model
{
    public partial class ContactContext : DbContext
    {
        public ContactContext()
        {

        }
        public ContactContext(DbContextOptions<ContactContext> contextOptions) : base(contextOptions)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer(@"Data Source =.; Initial Catalog = ContactDB; Persist Security Info=True;User ID=sa;Password=1234;MultipleActiveResultSets=True;Application Name=EntityFramework");
            }

            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Contact> Contacts { get; set; }

        public virtual DbSet<ToDo> ToDos { get; set; }

    }
}
