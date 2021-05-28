using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SEMYPROJECT.Models
{
  //[Table("区/县")]
  public class County
  {

    [Key] //Alt+回车
    [DisplayName("区/县编号")] //Alt+回车
    [MaxLength(15, ErrorMessage = "{0}长度不能超过{1}.")]
    public string CountyID { set; get; }

    [Required]
    [DisplayName("区/县名称")]
    [MaxLength(20, ErrorMessage = "{0}长度不能超过{1}.")]
    //[Index] //Alt+回车
    [Index("IX_County_CountyName", IsUnique = true, Order = 2)]
    public string CountyName { set; get; }

    [Required]
    //[ForeignKey(nameof(City))] 
    [DisplayName("所在地级市")]
    [MaxLength(15, ErrorMessage = "{0}长度不能超过{1}.")]
    [Index("IX_County_CountyName", IsUnique = true, Order = 1)]
    public string CityID { set; get; }

    //外键CityID对应的 Navigation Property!
    [ForeignKey("CityID")]
    public virtual City City { set; get; }

    //需要定义Student实体类：按Alt+回车 【在新文件中生成Student类】
    public virtual ICollection<Student> Students { set; get; }
  }
}