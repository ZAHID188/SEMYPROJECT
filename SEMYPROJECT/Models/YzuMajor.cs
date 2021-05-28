using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; //[DatabaseGenerated(~Option.None)]

namespace SEMYPROJECT.Models
{
  public class YzuMajor
  {
    [Key] //Alt+回车， 导入*.DataAnnotations
    [DatabaseGenerated(DatabaseGeneratedOption.None)] //数据库不自动产生值
    [DisplayName("专业编号")] //Alt+回车, 导入*.ComponentModel
    public int MajorID { set; get; }

    [Required]
    [DisplayName("专业名称")]
    [MaxLength(20)]
    [Index("IX_Major_MajorName", 2, IsUnique = true)]
    public string MajorName { set; get; }

    //外键 SchoolID
    [Required]
    [DisplayName("所在学院")]
    [Index("IX_Major_MajorName", 1, IsUnique = true)]
    //[ForeignKey(nameof(YzuSchool))]
    public int SchoolID { set; get; }

    [Required]
    [DisplayName("专业简拼")]
    [MaxLength(2)]
    public string MajorJianPin { set; get; }

    //外键 SchoolID 对应的导航字段
    [ForeignKey("SchoolID")]
    public virtual YzuSchool YzuSchool { set; get; }

    public virtual ICollection<Class> Classes { set; get; }
  }
}