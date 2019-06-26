using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ad_Link_Pro.Models
{
    public class EmployeesModel
    {
        public int Id { get; set; }

        [Display(Name ="اسم العميل")]
        [Required(ErrorMessage ="فضلا ادخل اسم العميل")]
        [RegularExpression(@"^[\u0600-\u065F\u066A-\u06EF\u06FA-\u06FFa-zA-Z]+[\u0600-\u065F\u066A-\u06EF\u06FA-\u06FFa-zA-Z-_\ ]*$", ErrorMessage = "يجب ان لا يحتوي الاسم على ارقام او رموز")]
        public string Name { get; set; }


        [Display(Name = "المدينة")]
        [Required(ErrorMessage = "فضلا ادخل اسم المدينة")]
        public string City { get; set; }


        [Display(Name = "العنوان")]
        [Required(ErrorMessage = "فضلا ادخل العنوان")]
        public string Address { get; set; }

        [Display(Name = "رقم الموبايل")]
        [StringLength(11,MinimumLength =11,ErrorMessage ="فضلا ادخل رقم هاتف صحيح")]  
        public string Phone1 { get; set; }

        [Display(Name = "2 رقم الموبايل")]
        public string Phone2 { get; set; }

        [Display(Name = "نشاط العميل")]
        [Required(ErrorMessage = "فضلا ادخل نشاط العميل")]
        public string Activity { get; set; }

        [Display(Name = "اسم المسؤول")]
        [Required(ErrorMessage = "فضلا ادخل اسم المسؤول")]
        public string RespoName { get; set; }
    }
}