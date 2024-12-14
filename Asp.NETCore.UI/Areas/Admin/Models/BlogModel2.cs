namespace Asp.NETCore.UI.Areas.Admin.Models
{
    public class BlogModel2
    {
        public int ID { get; set; }
        public string? BlogName { get; set; }
        public bool Durum { get; set; }
        public string? BlogContent { get; set; }
        public int? CategoryID { get; set; }
        public int? WriterID { get; set; }

    }
}
