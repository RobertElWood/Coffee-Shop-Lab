using System;
using System.Collections.Generic;

namespace Coffee_Shop_Lab.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string? Sizes { get; set; }
        public string? Calories { get; set; }
        public string? Description { get; set; }
    }
}
