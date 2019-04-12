using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Entities
{
    public class Image
    {
        [Key]
        public int ImageId { get; set; }
        [Required]
        public string AltText { get; set; }
        [Required]
        [Url]
        public string Url { get; set; }
        public List<Clothing> Clothing { get; set; }
    }
}
