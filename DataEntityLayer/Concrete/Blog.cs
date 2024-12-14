﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntityLayer.Concrete
{
    public class Blog
    {
        [Key]
        public int BlogID { get; set; }
        public string? BlogTitle { get; set; }
        public string? BlogContent { get; set; }
        public string? BlogThumnailImage { get; set; }
        public string? BlogImage { get; set; }
        public DateTime? BlogCreateDate { get; set; }
        public bool? BlogStatus { get; set; }
        public int? CategoryID { get; set; }
        public virtual Category? Category { get; set; }
        public List<Comment>? Comments { get; set; }
        public Writer? Writer { get; set; }
        public int? WriterID { get; set; }
        public int BlogSayisi { get; set; }
    }
}
