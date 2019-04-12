using DataLayer.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.Entities
{
    public class SortFilterSearchOptions
    {
        public int? BrandId { get; set; }
        public int? CategoryId { get; set; }
        public Colors? Color { get; set; }
        public Sizes? Size { get; set; }
        public string Search { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public SortOrder? SortOrder { get; set; }
    }

}
