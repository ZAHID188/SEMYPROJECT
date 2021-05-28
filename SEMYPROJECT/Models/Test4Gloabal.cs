using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SEMYPROJECT.Models
{
  public class Test4Gloabal
  {
    [Key]
    [DisplayName("编码")]
    public byte XNo { get; set; }

    [DisplayName("文本")]
    [Required]
    [MaxLength(1)]
    [Index("IX_Test4Gloabal_XName", IsUnique = true)]
    public string XName { get; set; }

    ////成绩表Scores 和用户表 Users 也加了备注
    //[MaxLength(10)]
    //[DisplayName("备注")]
    //public string Remark { get; set; }
  }
}