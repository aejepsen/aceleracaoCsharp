﻿namespace code_first.Models
// ok
{
    public class Category
    {
        public int CategoryId {get; set;}
        public string? Name {get; set;}
        public ICollection<Product>? Products {get; set;}
    }
}