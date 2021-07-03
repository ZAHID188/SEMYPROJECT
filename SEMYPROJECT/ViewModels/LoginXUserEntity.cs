using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc; //System.Web.Mvc.RemoteAttribute

namespace SE2018.ViewModels
{
  public class LoginXUserEntity
  {
    [Key]
    [Display(Name ="用户名")]
    [Required(ErrorMessage = "{0}必须填写(must be provided)!")]
    [Remote("CheckUserName", "JsonData", "Remote", ErrorMessage = "UserName does not exist!")]
    public string UserName { set; get; }

    [Display(Name ="密码")]
    [Required(ErrorMessage = "{0}必须填写(must be provided)!")]
    [DataType(DataType.Password)]
    [Remote("CheckPwd", "JsonData", "Remote", AdditionalFields = nameof(UserName), ErrorMessage = "{0}不正确(The pwd is not correct)!")]
    public string Pwd { set; get; }
  }
}