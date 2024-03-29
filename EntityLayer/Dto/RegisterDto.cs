﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dto
{
    public class RegisterDto
    {
        public int Id { get; set; }
        public string WriterName { get; set; }
        public string WriterAbout { get; set; }
        public string WriterMail { get; set; }
        public string WriterPassword { get; set; }
        public string? WriterPasswordAgain { get; set; }
        public bool WriterStatus { get; set; }
        public IFormFile WriterImage { get; set; }
    }
}
