using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SEMYPROJECT.Models
{
    [Table("city")]
    public class City
    {
        [Key]
        [Display(Name =" CIty id number")]
        [StringLength(20,ErrorMessage ="{0}length of number of city can't be more than{1}")]
        [Required]
        public string CityID { set; get; }
        [Required]
        [Display(Name ="city name")]
        [MaxLength(20,ErrorMessage ="{0} name can't be more than{1}")]
        [Index("IX_city_cityName",Order =2,IsUnique =true)]
        public string CityName { set;get }
        [Required]
        [Display (Name = "city name")]
        [MaxLength(15, ErrorMessage = "{0} name can't be more than{1}")]
        [Index("IX_city_cityName", Order = 1, IsUnique = true)]
        [ForeignKey()]
        public string ProvinceID { set; get; }
        // other need to be continued

    }
}