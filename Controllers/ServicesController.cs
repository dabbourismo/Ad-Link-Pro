using Ad_Link_Pro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static DataLibrary.BusinessLayer.ServicesProcessor;
namespace Ad_Link_Pro.Controllers
{
    public class ServicesController : Controller
    {
        List<ServicesModel> services;
        public ServicesController()
        {
            services = new List<ServicesModel>();
        }
        // GET: Services
        public ActionResult Index()
        {
            var servicesdata = LoadServices();
            //notice this is the model in the front end
            foreach (var row in servicesdata)
            {
                services.Add(new ServicesModel
                {
                    Id = row.Id,
                    ServiceName=row.ServiceName,
                    ServicePrice=row.ServicePrice,
                    ServiceTime=row.ServiceTime,
                    ServiceType=row.ServiceType
                });
            }
            return View(services);
        }

        /*--------------------------------------------------------------------------*/

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ServicesModel model)
        {
            //check model if it complies with data annotations validation rules but server side
            if (ModelState.IsValid)
            {
                //Add reference to DataLibrary
                InsertService(model.ServiceName, float.Parse(model.ServicePrice.ToString()), model.ServiceType, int.Parse(model.ServiceTime.ToString()));

                return RedirectToAction("Index");
            }
            return View();
        }
        /*--------------------------------------------------------------------------*/
        public ActionResult Delete(ServicesModel model)
        {
            var servicesdata = LoadServices(model.Id);
            foreach (var row in servicesdata)
            {
                services.Add(new ServicesModel
                {
                    Id = row.Id,
                    ServiceName = row.ServiceName,
                    ServicePrice = row.ServicePrice,
                    ServiceTime = row.ServiceTime,
                    ServiceType = row.ServiceType
                });
            }
            return View(services[0]);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                DeleteServices(id);
                TempData["Message"] = "تم المسح بنجاح";
                return RedirectToAction("Index");
            }
            return View();
        }
        /*--------------------------------------------------------------------------*/
        public ActionResult Edit(int id)
        {
            var servicesdata = LoadServices(id);
            foreach (var row in servicesdata)
            {
                services.Add(new ServicesModel
                {
                    Id = row.Id,
                    ServiceName = row.ServiceName,
                    ServicePrice = row.ServicePrice,
                    ServiceTime = row.ServiceTime,
                    ServiceType = row.ServiceType
                });
            }
            return View(services[0]);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ServicesModel model)
        {
            if (ModelState.IsValid)
            {
                //Add reference to DataLibrary
                UpdateServices(model.Id, model.ServiceName, model.ServicePrice, model.ServiceType, model.ServiceTime);
                TempData["Message"] = "تم التعديل بنجاح";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}