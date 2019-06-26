using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ad_Link_Pro.Models
{
    public class ServicesModel
    {
        public int Id { get; set; }
        [Display(Name = "اسم الخدمة")]
        [Required(ErrorMessage = "فضلا ادخل اسم الخدمة")]
        public string ServiceName { get; set; }
        [Display(Name = "سعر الخدمة")]
        [Range(0, float.MaxValue, ErrorMessage = "فضلا ادخل سعر الخدمة")]
        public float ServicePrice { get; set; }

        [Display(Name = "نوع الخدمة")]
        public string ServiceType { get; set; }


        [Display(Name = "زمن الخدمة بالأيام")]
        [Required(ErrorMessage = "فضلا ادخل زمن الخدمة")]
        public int ServiceTime { get; set; }
    }
}