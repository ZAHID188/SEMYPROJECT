using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SEMYPROJECT.Models.validators
{
  //static class: only provides consts and function, Not objects!
  public static class ValidationStrings
  {
    //public const string DateReg = @"^((?=.*\-.*\-)|(?=.*\..*\.)|(?=.*/.*/))(19|20)\d{2}[\-/\.]((0?[13578]|1[02])[\-/\.](0?[1-9]|[12]\d|3[01])|(0?[469]|11)[\-/\.](0?[1-9]|[12]\d|30)|(0?2)[\-/\.](0?[1-9]|[12]\d))$";
    //public const string DateErrMsg = "格式:yyyy-MM-dd(也可以用.或/作为分隔符,还需要注意年份必须是19XX或20XX)";

    public const string DateReg = @"^(19|20)\d{2}-(((0[13578]|1[02])-(0[1-9]|[12]\d|3[01]))|((0[469]|11)-(0[1-9]|[12]\d|30))|(02-(0[1-9]|[12]\d)))$";
    public const string DateErrMsg = "格式:yyyy-MM-dd，注意年月日的范围";

    public const string PwdReg = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[\W_]).*$";
    public const string PwdErrMsg = "{0}应包含大写字母、小写字母、数字和特殊字符!";

    public const string EmailReg = @"^\w+([\.\-]\w+)*@\w+(\.\w+)*\.[a-z]{2,3}$";
    public const string EmailErrMsg = "Email格式不对";

    public const string PhoneReg = @"^1[3-9]\d{9}|(0\d{2,3}\-?)?\d{7,8}$";
    public const string PhoneErrMsg = "{0}必须是11位手机号或者固定电话号码(有无区号均可)";

    public const string QQReg = @"^[1-9]\d{3,14}$";
    public const string QQErrMsg = "{0}必须为4~15位数字";

    public const string ImgUrlReg = @"^.*\.(jpg|jpeg|png|PNG)$";
    public const string ImgUrlErrMsg = "{0}必须是jpg、jpeg或png格式的文件";

    public const string UniqueErrMsg = "{0}不能重复!";

    public const string RemoteArea = "Remote";

    public const string MaxLen = "{0}不能超过{1}个字符!";
    public const string MinLen = "{0}不能少于{1}个字符!";
    public const string Unique = "{0}不能重复!";
  }
}