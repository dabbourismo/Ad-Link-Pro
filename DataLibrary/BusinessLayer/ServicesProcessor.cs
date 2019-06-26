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
    public static class ServicesProcessor
    {
        //dependancy inversion : high level modules shouldn't depend on low level modules + factory pattern
        static IServicesModel model;
        static ServicesProcessor()
        {
            model = Factory.CreateService();
        }
        public static int InsertService(string ServiceName,float ServicePrice,string ServiceType,int ServiceTime)
        {
            model.ServiceName = ServiceName;
            model.ServicePrice = ServicePrice;
            model.ServiceType = ServiceType;
            model.ServiceTime = ServiceTime;
     
            string sql = @"insert into dbo.Services (ServiceName,ServicePrice,ServiceType,ServiceTime)
                                              values (@ServiceName,@ServicePrice,@ServiceType,@ServiceTime)";
            return SQLDataAccess.ExecuteQuery(sql, model);
        }
        public static int UpdateServices(int Id,string ServiceName, float ServicePrice, string ServiceType, int ServiceTime)
        {
            model.Id = Id;
            model.ServiceName = ServiceName;
            model.ServicePrice = ServicePrice;
            model.ServiceType = ServiceType;
            model.ServiceTime = ServiceTime;
            string sql = @"update dbo.Services set ServiceName=@ServiceName,ServicePrice=@ServicePrice,
                            ServiceType=@ServiceType,ServiceTime=@ServiceTime where Id=@Id";
            return SQLDataAccess.ExecuteQuery(sql, model);
        }
        public static int DeleteServices(int Id)
        {
            model.Id = Id;
            string sql = @"delete from dbo.Services where Id=@Id";
            return SQLDataAccess.ExecuteQuery(sql, model);
        }
        public static List<ServicesModel> LoadServices()
        {
            string sql = @"select Id,ServiceName,ServicePrice,ServiceType,ServiceTime
                            from dbo.Services";

            return SQLDataAccess.LoadData<ServicesModel>(sql);
        }
        public static List<ServicesModel> LoadServices(int Id)
        {
            model.Id = Id;
            string sql = @"select Id,ServiceName,ServicePrice,ServiceType,ServiceTime
                            from dbo.Services where Id='" + model.Id + "'";

            return SQLDataAccess.LoadData<ServicesModel>(sql);
        }

    }
}
