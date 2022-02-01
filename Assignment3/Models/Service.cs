using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Assignment3.Models {
    [System.ComponentModel.DataAnnotations.Schema.Table("Services")]

    public class Service {
        public Service() {
            this.Customers = new HashSet<Customer>();
            this.Employees = new HashSet<Employee>();

        }
        public int Id {
            get; set;
        }
        public string Name {
            get; set;
        }
        public virtual ICollection<Customer> Customers {
            get; set;
        }
        public virtual ICollection<Employee> Employees {
            get; set;
        }
    }
}