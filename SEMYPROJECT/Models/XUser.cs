using SEMYPROJECT.Models.validators;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//[Key][Display][Required][StringLength]

namespace SEMYPROJECT.Models
{
  public class XUser
  {
    [Key] //Alt+回车 导入*.DataAnnotations
    [Display(Name = "用户名")]
    [Required]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "{0}只能由{2}~{1}个字符组成!")]
    [System.Web.Mvc.Remote("CheckName", "Users", "Remote", ErrorMessage = "{0}不能重复!")]
    public string Name { set; get; }

    [Required]
    [DisplayName("性别")] //Alt+回车 导入*.ComponentModel
    [ForeignKey(nameof(Gender))] //Alt+回车 导入*.Schema
    public byte GenderNo { set; get; }

    [DisplayName("密码")]
    [Required]
    [MaxLength(30)]
    [MinLength(6)]
    //[DataType(DataType.Password)]
    [RegularExpression(ValidationStrings.PwdReg, ErrorMessage = ValidationStrings.PwdErrMsg)] //Alt+回车 导入 *.validators
    public string Pwd { set; get; }

    //注意，确认密码【不需要持久化！】
    //  对于普通的私有字段，使用[NonSerialized]避免持久化。
    //  但对于set、get属性，则推荐使用定义于
    //  System.ComponentModel.DataAnnotations.Schema
    //   中的[NotMapped]:   
    [DisplayName("确认密码"), Compare("Pwd", ErrorMessage = "{0}与{1}必须相同!"), NotMapped]
    //[DataType(DataType.Password)]
    public string Pwd2 { set; get; }

    [Required] //【新增】
    [DisplayName("电话号码")]
    [Index("IX_User_Phone", IsUnique = true)]
    [MaxLength(13)]
    [RegularExpression(ValidationStrings.PhoneReg, ErrorMessage = ValidationStrings.PhoneErrMsg)]
    [System.Web.Mvc.Remote("CheckPhone", "Users", "Remote", AdditionalFields = "Name", ErrorMessage = "{0}不能重复!")]
    public string Phone { set; get; }

    [Required(ErrorMessage = "{0}不能为空!")]
    [Index("IX_User_Email", IsUnique = true)]
    [MaxLength(30)]
    [RegularExpression(ValidationStrings.EmailReg, ErrorMessage = ValidationStrings.EmailErrMsg)]
    [System.Web.Mvc.Remote("CheckEmail", "Users", "Remote", AdditionalFields = "Name", ErrorMessage = "{0}不能重复!")]
    public string Email { set; get; }

    //注意下面的出生日期的类型为string, 这里没有使用DateTime
    [DisplayName("出生日期"), MaxLength(10), Required(ErrorMessage = "{0}不能为空!")]
    //▼ 区分月份大小，但2月29天（不考虑闰年,闰年复杂了）
    //  合法的字符串    //[RegularExpression(@"^((?=.*\-.*\-)|(?=.*\..*\.)|(?=.*/.*/))\d{4}[\-/\.]((0?[13578]|10|12)[\-/\.](0?[1-9]|[12]\d|3[01])|(0?[469]|11)[\-/\.](0?[1-9]|[12]\d|30)|(0?2)[\-/\.](0?[1-9]|[12]\d))$", ErrorMessage = "{0}格式不对!")]
    //▼ 不区分月份大小,每个月01~31     //[RegularExpression(@"^((?=.*\-.*\-)|(?=.*\..*\.)|(?=.*/.*/))\d{4}[\-/\.](0?[1-9]|1[0-2])[\-/\.](0?[1-9]|[12]\d|3[01])$", ErrorMessage = "{0}格式不对!")]
    [RegularExpression(ValidationStrings.DateReg, ErrorMessage = ValidationStrings.DateErrMsg)]
    public string BornDate { set; get; }

    //成绩表Scores 和用户表 Users 加了备注
    [MaxLength(10)]
    [DisplayName("备注")]
    public string Remark { get; set; }

    public virtual Gender Gender { set; get; }
  }
}