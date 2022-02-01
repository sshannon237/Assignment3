using Assignment3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment3.ViewModels {
    public class EmployeeServiceViewModel {
        public Employee Employee {
            get; set;
        }
        public IEnumerable<SelectListItem> AllServices {
            get; set;
        }

        private List<int> _selectedServices;
        public List<int> SelectedServices {
            get {
                if(_selectedServices == null) {
                    _selectedServices = Employee.Services.Select(m => m.Id).ToList();
                }
                return _selectedServices;
            }
            set {
                _selectedServices = value;
            }
        }
    }
}