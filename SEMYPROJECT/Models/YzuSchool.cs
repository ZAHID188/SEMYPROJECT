using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SEMYPROJECT.Models
{
  //Alt+回车: 导入*.Schema
  //[Table("School")] //数据库对应的表名为School
  public class YzuSchool
  {
    //注意，对于int型主键,
    //  ❶ DatabaseGenerated 默认选项为 
    //    DatabaseGeneratedOption.Identity : 
    //       插入或更新时，由数据库生成值, 从1开始。
    //  ❷ 如果想自定义int型主键列的值，则应显示使用
    //     DatabaseGeneratedOption.None : 数据库不生成值。
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)] //【两次Alt+回车】 导入*.DataAnnotations 和 *.Schema
    [DisplayName("学院编号")] //Alt+回车, 导入*.ComponentModel
    public int SchoolID { set; get; }

    [Required]
    [DisplayName("学院名称")]
    [MaxLength(20)]
    [Index("IX_School_SchoolName", IsUnique = true)]
    public string SchoolName { set; get; }

    [Required]
    [DisplayName("学院简拼")]
    [MaxLength(2)]
    public string SchoolJianPin { set; get; }

    public virtual ICollection<YzuMajor> Majors { set; get; }
  }
}