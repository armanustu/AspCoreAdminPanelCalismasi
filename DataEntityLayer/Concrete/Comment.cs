using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntityLayer.Concrete
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }
        public string? CommentUserName { get; set; }
        public string? CommentTitle { get; set; }
        public string? CommentContent { get; set; }
        public DateTime? CommentDate { get; set; }
        public bool? Commentstatus { get; set; }
        public int? WriterID { get; set; }
        public int? BlogID { get; set; }
        public virtual Blog? Blog { get; set; }
        public int BlogScore { get; set; }

    }
}
