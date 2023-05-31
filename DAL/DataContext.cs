using System;
using System.Data.Entity;

namespace DAL
{
    public class DataContext : DbContext
    {
        public DataContext() : base("name=DataContext")
        {
        }

        public DbSet<Designer> Designers { get; set; }

    }

}