using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SEMYPROJECT.Models
{
  public class RoleWithControllerAction
  {
    [Required]
    [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { set; get; }
     
    [MaxLength(20, ErrorMessage = "{0}长度不能超过{1}个字符!")]
    public string AreaName { set; get; }

    [Required]
    [MaxLength(30, ErrorMessage = "{0}长度不能超过{1}个字符!")]
    public string ControllerName { set; get; }

    [Required]
    [MaxLength(30, ErrorMessage = "{0}长度不能超过{1}个字符!")]
    public string ActionName { set; get; }

    [Required]
    [MaxLength(20)]
    public string RoleIds { set; get; }
  }
}