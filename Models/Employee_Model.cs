using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeForm.Models
{
    public class Employee_Model
    {
        public List<tbl_Employee> Employees { get; set; }
        public int statuscode { get; set; }
       public string statusmessage { get; set; }
       
    }
}