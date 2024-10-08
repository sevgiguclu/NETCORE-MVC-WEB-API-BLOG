﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayout.Model
{
    public class Tag
    {
        [Key]
        public int ID {  get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public ICollection<ArticleTag> ArticleTags { get; set; } // Many-to-Many ilişki için

    }
}
