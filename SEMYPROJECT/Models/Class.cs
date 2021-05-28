using System.Collections.Generic; //ICollection<T>
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; //用到 [Index], [ForeignKey]
using System.Web.Mvc;

namespace SEMYPROJECT.Models
{
  //[Table("班级")]
  public class Class //: BaseEntity
  {
    [Key]
    [Required]
    [Display(Name = "班级编号")]
    [MaxLength(8)]
    //~/Areas/Remote/JsonData/CheckNewClassNo
    //         区域
    //               控制器
    //                         返回Json数据的Action/方法
    [Remote("CheckNewClassNo", "JsonData", "Remote",
      ErrorMessage = "{0}已经存在!")]
    public string ClassNo { get; set; }

    [Required]
    [Display(Name = "班级名称")]
    [MaxLength(10)]
    [Index("IX_Class_ClassName", IsUnique = true)]
    [Remote("CheckUniqueClassName", "JsonData", "Remote",
      AdditionalFields = "ClassNo", 
      ErrorMessage = "{0}不能重复!")]
    public string ClassName { get; set; }

    //外键 MajorID
    //[Required]
    [Display(Name = "所在专业")]
    //[ForeignKey("YzuMajor")]
    //[ForeignKey(nameof(YzuMajor))]
    //  这个int 类型也能自动起到验证的作用
    public int MajorID { set; get; }

    // 外键 MajorID 对应的导航字段 
    //[ForeignKey("MajorID")]
    [ForeignKey(nameof(MajorID))]
    public virtual YzuMajor YzuMajor { set; get; }

    public virtual ICollection<Student> Students { get; set; }
  }
}