using SEMYPROJECT.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SEMYPROJECT.ViewModels
{
    public class EditableStudent :Student
    {
        [Display(Name="Province/city")]
        public string ProvinceID { get; set; }
        [Display(Name = "city")]
        public string CityID { get; set; }
        [Display(Name = "School")]
        public int SchoolID { get; set; }
        [Display(Name = "Major")]
        public int MajorID { get; set; }
    }
}