using Assignment3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment3.ViewModels {
    public class CustomerServiceViewModel {
        public Customer Customer {
            get; set;
        }
        public IEnumerable<SelectListItem> AllServices {
            get; set;
        }

        private List<int> _selectedServices;
        public List<int> SelectedServices {
            get {
                if(_selectedServices == null) {
                    _selectedServices = Customer.Services.Select(m => m.Id).ToList();
                }
                return _selectedServices;
            }
            set {
                _selectedServices = value;
            }
        }
    }
}