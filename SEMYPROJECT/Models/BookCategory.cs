using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SEMYPROJECT.Models
{
  public class BookCategory
  {
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    [DisplayName("图书分类编号")]
    [Required]
    public int CategoryID { set; get; }
    [DisplayName("图书分类名称")]
    [MaxLength(50)]
    [Required]
    public string CategoryName { set; get; }

    public virtual ICollection<BookInfo> BookInfos { set; get; }
  }
}