using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
namespace Assignment3.Models {

    public class ApplicationDbContext : DbContext {
        public ApplicationDbContext()
            : base("DefaultConnection") {
        }
        public DbSet<Person> People {
            get; set;
        }
        public DbSet<Service> Services {
            get; set;
        }
        public DbSet<Customer> Customers {
            get; set;
        }
        public DbSet<Employee> Employees     {
            get; set;
        }

    }
}