﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multishop.WebDTO.DTOs.CommentDtos
{
    public class CreateCommentDto
    {
       
        public string NameSurname { get; set; }
        public string? ImageUrl { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public DateTime CommentDate { get; set; }
        public bool Status { get; set; }

        public string ProductId { get; set; }
    }
}
