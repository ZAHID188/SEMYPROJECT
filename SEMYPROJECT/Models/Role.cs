using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SEMYPROJECT.Models
{
  public class Role
  {
    [Required]
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { set; get; }

    [Required]
    [MaxLength(10, ErrorMessage = "{0}长度不能超过{1}个字符!")]
    public string RoleName { set; get; }

    [Required]
    [MaxLength(10, ErrorMessage = "{0}长度不能超过{1}个字符!")]
    public string Description { set; get; }

    public virtual ICollection<User> Users { get; set; }
  }
}