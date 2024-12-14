using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntityLayer.Concrete
{
    public class Writer
    {
        [Key]
        public int WriterID { get; set; }
        [DisplayName("Yazar Hakkında")]
        public string? WriterAbout { get; set; }
        [DisplayName("Yazar Resim")]
        public string? WriterImage { get; set; }
        [DisplayName("Yazar Mail")]
        public string? WriterMail { get; set; }
        [DisplayName("Yazar Durum")]
        public bool? WriterStatus { get; set; }
        [DisplayName("Yazar ismi")]
        public string? WriterName { get; set; }
        [DisplayName("Yazar Pasword")]
        public string? WriterPassword { get; set; }
        [DisplayName("Tekrar Şifre")]
        public string? RepeatPassword  { get; set; }
        public List<Blog>? Blogs { get; set; }
    }
}
