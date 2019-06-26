using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class ServicesModel : IServicesModel
    {
        public int Id { get; set; }
        public string ServiceName { get; set; }
        public float ServicePrice { get; set; }
        public string ServiceType { get; set; }
        public int ServiceTime { get; set; }
    }
}
