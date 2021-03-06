using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Assignment3.Models {
    [System.ComponentModel.DataAnnotations.Schema.Table("Employees")]
    public class Employee : Person {
        public Employee() {
            this.Services = new HashSet<Service>();
        }
        public int Salary {
            get; set;
        }
        public virtual ICollection<Service> Services {
            get; set;
        }
    }
}