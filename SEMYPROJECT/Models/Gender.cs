using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SEMYPROJECT.Models
{
  public class Gender
  {
    [Key]
    [DisplayName("性别编码")]
    public byte GenderNo { get; set; }

    [DisplayName("性别")]
    [Required]
    [MaxLength(1)]
    [Index("IX_Gender_GenderName", IsUnique = true)]
    public string GenderName { get; set; }

    public virtual ICollection<Student> Students { get; set; }
    //Alt+回车  【在新文件中生成 User 类】
    public virtual ICollection<XUser> Users { get; set; }
  }
}