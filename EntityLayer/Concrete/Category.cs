﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Category
    {
        [Key]
        public int CatergoryId { get; set; }
        public string CategoryName { get; set; }
        public string CatergoryDescription { get; set; }
        public bool CategoryStatus { get; set; }
        public List<Blog> Blogs { get; set; }
    }
}
