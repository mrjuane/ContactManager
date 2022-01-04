
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
        IConfiguration config;
        public ContactContext()
        {
          
        }
        public ContactContext(DbContextOptions<ContactContext> contextOptions) : base(contextOptions)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            var build = new ConfigurationBuilder();
            build.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", true, true);
            config = build.Build();


            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));// @"Data Source =.; Initial Catalog = ContactDB; Persist Security Info=True;User ID=sa;Password=1234;MultipleActiveResultSets=True;Application Name=EntityFramework");
            }

            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Contact> Contacts { get; set; }

        public virtual DbSet<ToDo> ToDos { get; set; }

    }
}
