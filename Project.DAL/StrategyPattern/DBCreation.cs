using Project.DAL.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Entities.Models;
using Project.Entities.Enums;


namespace Project.DAL.StrategyPattern
{
    public class DBCreation:CreateDatabaseIfNotExists<MyContext>
    {
        protected override void Seed(MyContext context)
        {

        }
    }
}
