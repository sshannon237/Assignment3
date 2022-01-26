using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Assignment3.Models {
    [System.ComponentModel.DataAnnotations.Schema.Table("Customers")]
    public class Customer : Person {
        public Customer() {
            this.Services = new HashSet<Service>();
        }
        public virtual ICollection<Service> Services {
            get; set;
        }

    }
}