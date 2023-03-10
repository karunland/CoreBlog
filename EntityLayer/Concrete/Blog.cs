using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Blog
    {
        [Key]
        public int BlogId { get; set; }
        public string? BlogTitle { get; set;}
        public string? BlogContent { get; set;}
        public string? BlogThumbnailImage { get; set;}
        public string? BlogImage { get; set;}
        public DateTime? BlogCreateDate { get; set;}
        public bool? BlogStatus { get; set;}
        public int CatergoryId { get; set; }
        public Category RCategory { get; set; }
        public int? WriterId { get; set; }
        public Writer Writer { get; set; }
        public List<Contact> Comments { get; set; }
    }
}
