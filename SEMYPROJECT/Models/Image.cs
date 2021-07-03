using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SEMYPROJECT.Models
{
    public class Image
    {
      
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }


        public string Title { set; get; }


        [DisplayName("upload file")]
        public string ImagePath { set; get; }


        public HttpPostedFileBase ImageFile { set; get; }
    }
}