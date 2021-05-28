using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SEMYPROJECT.Models
{
  public class Press
  {
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Display(Name = "出版社编号")]
    [Required]
    public int PressID { set; get; }
    [Display(Name = "出版社名称")]
    [StringLength(20)]
    [Required]
    public string PressName { set; get; }
    [Required]
    public string CityID { set; get; }
    [Display(Name = "详细地址")]
    [StringLength(100)]
    [Required]
    public string Address { set; get; }

    [ForeignKey(nameof(CityID))]
    public virtual City City { set; get; }
    public virtual ICollection<BookInfo> BookInfos { set; get; }
  }
}