using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SEMYPROJECT.Models
{
  public class CourseType
  {
    [Key]
    [DisplayName("课程类型编号")]
    public byte CourseTypeNo { get; set; }

    [Required]
    [DisplayName("课程类型名称")]
    [MaxLength(6)]
    [Index("IX_CourseType_CourseTypeName", IsUnique = true)]
    public string CourseTypeName { get; set; }

    //Alt+回车 导入 System.Collections.Generic
    //Alt+回车 【在新文件中生成  Course类】
    public virtual ICollection<Course> Courses { get; set; }
  }
}