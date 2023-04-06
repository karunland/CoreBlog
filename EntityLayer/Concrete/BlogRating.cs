using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class BlogRating
    {
        public int Id { get; set; }
        public int BLogId { get; set; }
        public int TotalScore { get; set; }
        public int RatingCount { get; set; }
    }
}
