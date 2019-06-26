using DataLibrary.DataAccess;
using DataLibrary.FactoryClasses;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DataLibrary.BusinessLayer
{
    public static class EmployeesProcessor
    {
        //dependancy inversion : high level modules shouldn't depend on low level modules + factory pattern
        static IEmployeesModel model;
        static EmployeesProcessor()
        {
            model = Factory.CreateEmployee();
        }
        public static int InsertEmployee(string Name, string City, string Address, string Phone1, string Phone2,
                                                        string Activity, string RespoName)
        {
            //the datalibrary model Not the front end model
            model.Name = Name;
            model.City = City;
            model.Address = Address;
            model.Phone1 = Phone1;
            model.Phone2 = Phone2;
            model.Activity = Activity;
            model.RespoName = RespoName;
            string sql = @"insert into dbo.Employees (Name,City,Address,Phone1,Phone2,Activity,RespoName)
                                              values (@Name,@City,@Address,@Phone1,@Phone2,@Activity,@RespoName)";
            return SQLDataAccess.ExecuteQuery(sql, model);
        }
        public static int UpdateEmployee(int Id,string Name, string City, string Address, string Phone1, string Phone2,
                                                        string Activity, string RespoName)
        {
            model.Id = Id;
            model.Name = Name;
            model.City = City;
            model.Address = Address;
            model.Phone1 = Phone1;
            model.Phone2 = Phone2;
            model.Activity = Activity;
            model.RespoName = RespoName;
            string sql = @"update dbo.Employees set Name=@Name,City=@City,Address=@Address,
                           Phone1=@Phone1,Phone2=@Phone2,Activity=@Activity,RespoName=@RespoName where Id=@Id";
            return SQLDataAccess.ExecuteQuery(sql, model);
        }
        public static int DeleteEmployee(int Id)
        {
            model.Id = Id;
            string sql = @"delete from dbo.Employees where Id=@Id";
            return SQLDataAccess.ExecuteQuery(sql, model);
        }

        public static List<EmployeesModel> LoadEmployees()
        {
            string sql = @"select Id,Name,City,Address,Phone1,Phone2,Activity,RespoName
                            from dbo.Employees";

            return SQLDataAccess.LoadData<EmployeesModel>(sql);
        }
        public static List<EmployeesModel> LoadEmployees(int Id)
        {
            model.Id = Id;
            string sql = @"select Id,Name,City,Address,Phone1,Phone2,Activity,RespoName
                            from dbo.Employees where Id='"+model.Id+"'";

            return SQLDataAccess.LoadData<EmployeesModel>(sql);
        }

    }
}
