using System;
using System.Collections.Generic;
using Project.Entities.Models;
using System.Data.Entity;
using System.Linq;
using Project.MAP.Options;
using System.Text;
using System.Threading.Tasks;
using Project.DAL.StrategyPattern;

namespace Project.DAL.Context
{
    public class MyContext : DbContext
    {
        public MyContext() : base("myConnection")
        {
            Database.SetInitializer(new DBCreation());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CountryMap());

        }

        public DbSet<CountryInformation> CountryInformations { get; set; }
    }
}
