using System; //Nullable<T>, DateTime
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SEMYPROJECT.Models
{
  public class Score
  {
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }

    [Display(Name = "学生")]
    [Required]
    [MaxLength(11)]
    [ForeignKey(nameof(Student))]
    [Index("IX_Score_SNo_CNo", IsUnique = true, Order = 1)]
    public string SNo { get; set; }

    [Required]
    [DisplayName("课程")]
    [MaxLength(12)]
    [ForeignKey(nameof(Course))]
    [Index("IX_Score_SNo_CNo", IsUnique = true, Order = 2)]
    public string CNo { get; set; }

    [DisplayName("成绩")]
    //按Alt+回车 导入 System;
    public Nullable<short> Mark { get; set; }

    //成绩表Scores 和用户表 Users 加了备注
    [MaxLength(10)]
    [DisplayName("备注")]
    public string Remark { get; set; }

    [DisplayName("考试日期")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    //System.Nullabe<T>, System.DateTime
    public Nullable<DateTime> DateOfExam { get; set; }

    public virtual Student Student { get; set; }
    public virtual Course Course { get; set; }
  }
}