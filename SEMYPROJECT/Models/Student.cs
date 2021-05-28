using SEMYPROJECT.Models.validators; //RegularExp
using System; //System.DateTime
using System.Collections.Generic; //ICollection<T>
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc; //[Remote(...)]：远程验证

namespace SEMYPROJECT.Models
{
  //[Table("学生")]
  public class Student
  {
    [Key] //Alt+回车
    [Required]
    [Display(Name = "学号")]
    [MinLength(5, ErrorMessage = "{0}长度不能小于{1}")]
    [MaxLength(11, ErrorMessage = "{0}长度不能大于{1}")]
    //▼ Alt+回车 导入System.Web.Mvc;
    [Remote("CheckSNo", "Students", ValidationStrings.RemoteArea, ErrorMessage = ValidationStrings.UniqueErrMsg)]
    public string SNo { get; set; }

    [DisplayName("姓名")] //Alt+回车
    [Required]
    [MaxLength(12, ErrorMessage = "{0}长度不能大于{1}")]
    public string SName { get; set; }

    [DisplayName("性别")]
    [ForeignKey(nameof(Gender))]
    public byte GenderNo { get; set; }

    [Required]
    [DisplayName("出生日期")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime BornDate { get; set; }

    [Required]
    [DisplayName("籍贯")]
    [ForeignKey(nameof(County))] //
    [Remote("CheckCountyID", "Students", "Remote", ErrorMessage = "{0}:区/县必须做出选择!")]
    public string BornCountyID { set; get; }

    [Required]
    [DisplayName("QQ号")]
    [Index("IDX_Student_QQ", IsUnique = true)]
    [MaxLength(15)]
    [RegularExpression(ValidationStrings.QQReg, ErrorMessage = ValidationStrings.QQErrMsg)]
    [Remote("CheckQQ", "Students", "Remote", AdditionalFields = nameof(SNo), ErrorMessage = ValidationStrings.UniqueErrMsg)]
    public string QQ { get; set; }

    [Required]
    [Display(Name = "电话/手机")]
    [Index("IX_Student_Phone", IsUnique = true)]
    [MaxLength(13)]
    [RegularExpression(ValidationStrings.PhoneReg, ErrorMessage = ValidationStrings.PhoneErrMsg)]
    [Remote("CheckPhone", "Students", ValidationStrings.RemoteArea, AdditionalFields =nameof(SNo), ErrorMessage = ValidationStrings.UniqueErrMsg)]
    public string Phone { get; set; }

    [Required]
    [Index("IX_Student_Email", IsUnique = true)]
    [MaxLength(30)]
    [RegularExpression(ValidationStrings.EmailReg, ErrorMessage = ValidationStrings.EmailErrMsg)]
    [Remote("CheckEmail", "Students", ValidationStrings.RemoteArea, AdditionalFields = nameof(SNo), ErrorMessage = ValidationStrings.UniqueErrMsg)]
    public string Email { get; set; }

    [DisplayName("个人图像")]
    [MaxLength(50)]
    [RegularExpression(ValidationStrings.ImgUrlReg, ErrorMessage = ValidationStrings.ImgUrlErrMsg)]
    // 显示文件名（不可直接编辑，只能通过上传文件来设置）, 数据库表中存储文件名
    public string AvatarPath { get; set; }

    [NotMapped]
    // 上传个人图像的input元素
    public string AvatarUploader { get; set; }

    [DisplayName("照片")]
    // 与个人图像不同的是，这里是byte[]类型，
    //   数据库表中存储图片的二进制文件，而不是文件名
    //   Ref. 
    public byte[] PhotoData { get; set; }
    public string PhotoMimeType { get; set; }
    /*MIME (Multipurpose Internet Mail Extensions) 
     * 是描述消息内容类型的因特网标准。
     * MIME 消息能包含文本、图像、音频、视频以及其他应用程序专用的数据。
     * 不同的应用程序支持不同的 MIME 类型。
     * Ref: https://www.w3school.com.cn/media/media_mimeref.asp/
     * */

    [Required]
    [DisplayName("班级")]
    [ForeignKey(nameof(Class))]
    [Remote("CheckClassNo", "Students", "Remote", ErrorMessage = "必须选择{0}!")]
    [MaxLength(8)]
    public string ClassNo { get; set; }


    //[ForeignKey("GenderNo")]
    //[ForeignKey(nameof(GenderNo))]
    public virtual Gender Gender { get; set; } //外键GenderNo对应的导航字段

    //外键 ClassNo 对应的导航字段
    //[ForeignKey("ClassNo")]
    public virtual Class Class { get; set; }
    //外键 ClassNo 对应的导航字段
    //[ForeignKey("BornCountyID")]
    public virtual County County { get; set; }

    public virtual ICollection<Score> Scores { get; set; }
  }
}