using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SEMYPROJECT.Models
{
  public class Author
  {
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Display(Name = "编号")]
    [Required]
    public int AuthorID { set; get; }
    [Display(Name = "姓名")]
    [Required]
    [StringLength(20, MinimumLength = 2, ErrorMessage = "{0}长度应介于{2}~{1}之间.")]
    public string AuthorName { set; get; }
    [Display(Name = "性别")]
    [Required]
    public byte GenderNo { set; get; }
    [DisplayName("备注")]
    [MaxLength(200)]
    public string Remark { set; get; }
    [Display(Name = "图片")]
    [MaxLength(200)]
    [RegularExpression(@"^.*\.(jpg|JPG|png|PNG)$", ErrorMessage = "{0}必须为jpg或png格式的文件!")]
    public string PhotoPath { set; get; }

    [ForeignKey(nameof(GenderNo))]
    public virtual Gender Gender { set; get; }
    public virtual ICollection<BookInfo> BookInfos { set; get; }
  }
}