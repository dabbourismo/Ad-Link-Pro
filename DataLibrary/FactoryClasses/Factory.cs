using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.FactoryClasses
{
    public static class Factory
    {
        public static IEmployeesModel CreateEmployee()
        {
            return new EmployeesModel();
        }
        public static IServicesModel CreateService()
        {
            return new ServicesModel();
        }

    }
}
