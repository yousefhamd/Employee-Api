using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task3.Models
{
    public class Employee
    {
        public int? ID { set; get; }
        public string Name { set; get; }
        public int? Salary { set; get; }
        public bool? IsMarried { set; get; }
    }
}