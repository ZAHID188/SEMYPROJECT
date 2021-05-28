using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SEMYPROJECT.Models
{
  public class BookInfo
  {
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    [DisplayName("图书编号")]
    [Required]
    public int BookID { set; get; }
    [DisplayName("图书分类")]
    [Required]
    public int CategoryID { set; get; }
    [DisplayName("书名")]
    [Required]
    [StringLength(50, ErrorMessage = "{0}长度不能小于{1}.")]
    public string BookName { set; get; }
    [StringLength(20, MinimumLength = 8, ErrorMessage = "{0}长度应介于{2}~{1}之间.")]
    [Required]
    public string ISBN { set; get; }
    [Required]
    public int PressID { set; get; }
    [DisplayName("价格")]
    public double? Price { set; get; }
    public int AuthorID { set; get; }
    [DisplayName("出版年月")]
    public DateTime? PublishDate { set; get; }
    [DisplayName("版次")]
    public short? Version { set; get; }
    [DisplayName("封面")]
    [StringLength(200, MinimumLength = 5, ErrorMessage = "{0}长度应该介于{2}~{1}之间.")]
    [RegularExpression(@"/^*\.(jpg|png)$/", ErrorMessage = "{0}文件必须是jpg或png图片!")]
    public string CoverPath { set; get; }

    [ForeignKey(nameof(CategoryID))]
    public virtual BookCategory BookCategory { set; get; }
    [ForeignKey(nameof(PressID))]
    public virtual Press Press { set; get; }
    [ForeignKey(nameof(AuthorID))]
    public virtual Author Author { set; get; }
  }
}