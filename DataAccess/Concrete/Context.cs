using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Entity.Base;

namespace SamiProje.DataAccess.Concrete
{
	public class Context : DbContext
	{
		
        public Context()
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			
			optionsBuilder.UseSqlServer("Server=MR-ROBOT;Database=SamiDENEMEPROJESİ;Trusted_Connection=True;TrustServerCertificate=True;");
		}

        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries<BaseEntity>();
            foreach (var entity in entries)
            {
                if (EntityState.Added == entity.State)
                {
                    entity.Entity.CreatedDate = DateTime.Now;
                    entity.Entity.UpdatedDate = DateTime.Now;
                }
                else
                    entity.Entity.UpdatedDate = DateTime.Now;

            }
            return base.SaveChanges();
        }
        public DbSet<Departmant> Departmants { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Title> Titles { get; set; }
    }
}
