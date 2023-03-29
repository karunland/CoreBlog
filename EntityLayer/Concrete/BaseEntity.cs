using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class BaseEntity
    {
        public bool isDeleted { get; set; } = false;
        public DateTime CreatedDate { get; set; } = DateTime.Parse(DateTime.Now.ToString());
        public DateTime DeletedDate { get; set; }

    }
}
