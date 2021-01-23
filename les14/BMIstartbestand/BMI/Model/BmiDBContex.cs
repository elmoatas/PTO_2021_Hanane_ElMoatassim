using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMI.Model
{
    class BmiDBContex: DbContext
    {
        public BmiDBContex() : base("data source=(localdb)\\MSSQLLocalDB; initial catalog=BmiDB")
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<BMI> BMIs { get; set; }
    }
}
