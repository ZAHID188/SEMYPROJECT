using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SE2018.ViewModels
{
  public class SCMark
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int ID { get; set; }

    [Display(Name ="学号")]
    public string SNo { get; set; }
    [Display(Name ="姓名")]
    public string SName { get; set; }
    [Display(Name ="课程号")]
    public string CNo { get; set; }
    [Display(Name ="课程名")]
    public string CName { get; set; }
    [Display(Name ="成绩")]
    public Nullable<short> Mark { get; set; }
  }
}