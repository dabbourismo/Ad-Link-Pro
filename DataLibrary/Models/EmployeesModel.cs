using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class EmployeesModel : IEmployeesModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Activity { get; set; }
        public string RespoName { get; set; }
        
    }
}
