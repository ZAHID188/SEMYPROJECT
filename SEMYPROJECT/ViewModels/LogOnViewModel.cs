using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SE2018.ViewModels
{
  public class LogOnViewModel
  {
    [Key]
    [Display(Name ="用户名")]
    [System.Web.Mvc.Remote("CheckUserName", "Users", "Remote", ErrorMessage = "{0} does not exist!")]
    public string UserName { set; get; }

    [Display(Name ="密码")]
    [DataType(DataType.Password)]
    [System.Web.Mvc.Remote("CheckUserPwd", "Users", "Remote", AdditionalFields = nameof(UserName), ErrorMessage ="{0} is not right!")]
    public string Password { set; get; }

    [Display(Name ="Remember me~")]
    public bool RememberMe { set; get; }
  }
}