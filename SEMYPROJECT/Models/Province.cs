using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;// For key attribute
using System.ComponentModel.DataAnnotations.Schema;// for [Table("templateinprovince")]
using System.Linq;
using System.Web;

namespace SEMYPROJECT.Models
{
    //this is a codeFirstdb

        [Table("templateinprovince")]
    public class Province
    {
        [Key]
        [Display(Name=" displaypname")]
        [MaxLength(15,ErrorMessage ="{0}not more than{1}.")]
        [Required]
        public string ProvinceID { set; get; }

        [Required]
        [Display(Name =" Name of province")]
        [StringLength(20,ErrorMessage ="{0} name cant be more than{1}.")]
        // province name can't be same
        [Index("IX_Province_ProvinceName",IsUnique =true)]
        public string ProvinceName { set; get; }

    }
}