﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multishop.WebDTO.DTOs.ImageDtos
{
    public class UpdateImageDto
    {
        public int Id { get; set; }
        public string Title { get; set; }


        public IFormFile? Photo { get; set; }
        public string? SavedUrl { get; set; }

     
        public string? SignedUrl { get; set; }
        public string? SavedFileName { get; set; }
    }
}
