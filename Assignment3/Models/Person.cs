using System.ComponentModel.DataAnnotations;

namespace Assignment3.Models {
    public class Person {
        public int Id {
            get; set;
        }
        public string Name {
            get; set;
        }
        public string Address {
            get; set;
        }
    }
}