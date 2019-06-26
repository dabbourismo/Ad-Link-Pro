using Ad_Link_Pro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLibrary;
using static DataLibrary.BusinessLayer.EmployeesProcessor;

namespace Ad_Link_Pro.Controllers
{
    public class EmployeesController : Controller
    {
        List<EmployeesModel> employees;
        public EmployeesController()
        {
            employees = new List<EmployeesModel>();
        }
        // GET: Employees
        public ActionResult Index()
        {
            //the data of model in datalibrary
            var employeesdata = LoadEmployees();
            //notice this is the model in the front end

            foreach (var row in employeesdata)
            {
                employees.Add(new EmployeesModel
                {
                    Id = row.Id,
                    Name = row.Name,
                    City = row.City,
                    Address = row.Address,
                    Phone1 = row.Phone1,
                    Phone2 = row.Phone2,
                    Activity = row.Activity,
                    RespoName = row.RespoName
                });
            }
            return View(employees);
        }
        /*--------------------------------------------------------------------------*/
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeesModel model)
        {
            //check model if it complies with data annotations validation rules but server side
            if (ModelState.IsValid)
            {
                //Add reference to DataLibrary
                InsertEmployee(model.Name, model.City, model.Address, model.Phone1,
                                model.Phone2, model.Activity, model.RespoName);

                return RedirectToAction("Index");
            }
            return View();
        }
        /*--------------------------------------------------------------------------*/
        public ActionResult Delete(EmployeesModel model)
        {
            var employeesdata = LoadEmployees(model.Id);
            foreach (var row in employeesdata)
            {
                employees.Add(new EmployeesModel
                {
                    Id = row.Id,
                    Name = row.Name,
                    City = row.City,
                    Address = row.Address,
                    Phone1 = row.Phone1,
                    Phone2 = row.Phone2,
                    Activity = row.Activity,
                    RespoName = row.RespoName
                });
            }
            return View(employees[0]);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                DeleteEmployee(id);
                TempData["Message"] = "تم المسح بنجاح";
                return RedirectToAction("Index");
            }
            return View();
        }
        /*--------------------------------------------------------------------------*/
        public ActionResult Edit(int id)
        {
            var employeesdata = LoadEmployees(id);
            foreach (var row in employeesdata)
            {
                employees.Add(new EmployeesModel
                {
                    Id = row.Id,
                    Name = row.Name,
                    City = row.City,
                    Address = row.Address,
                    Phone1 = row.Phone1,
                    Phone2 = row.Phone2,
                    Activity = row.Activity,
                    RespoName = row.RespoName
                });
            }
            return View(employees[0]);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmployeesModel model)
        {
            if (ModelState.IsValid)
            {
                //Add reference to DataLibrary
                UpdateEmployee(model.Id, model.Name, model.City, model.Address, model.Phone1,
                                model.Phone2, model.Activity, model.RespoName);
                TempData["Message"] = "تم التعديل بنجاح";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}