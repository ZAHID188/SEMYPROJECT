using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SEMYPROJECT.Models
{
  public class Course
  {
    [Key]
    [DisplayName("课程编号")]
    [MaxLength(12)]
    public string CNo { get; set; }

    [Required]
    [DisplayName("课程名称")]
    [MaxLength(20)]
    public string CName { get; set; }

    [DisplayName("理论学时")]
    [Required]
    public byte ClassPeriods { get; set; }

    [DisplayName("实验学时")]
    [Required]
    public byte ExperimentPeriods { get; set; }

    [DisplayName("课程类型")]
    [Required]
    [ForeignKey(nameof(CourseType))]
    public byte CourseTypeNo { get; set; } //外键CourseTypeNo

    [DisplayName("学分")]
    [Required]
    public double Credit { get; set; }

    //[ForeignKey("CourseTypeNo")]
    //CourseTypeNo对应的导航字段
    public virtual CourseType CourseType { get; set; }

    public virtual ICollection<Score> Scores { get; set; }
  }
}