using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SEMYPROJECT.Models
{
  public class User
  {
    //System.ComponentModel.DataAnnotations.KeyAttribute
    //System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Required]
    public int Id { set; get; }

    [Required]
    [MaxLength(30, ErrorMessage = "{0}长度不能超过{1}个字符!")]
    public string UserName { set; get; }

    [Required]
    [MaxLength(30, ErrorMessage = "{0}长度不能超过{1}个字符!")]
    public string Password { set; get; }

    public int RoleId { set; get; }

    [ForeignKey(nameof(RoleId))]
    public virtual Role Role { set; get; }
  }
}