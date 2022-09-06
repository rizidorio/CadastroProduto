﻿using CadastroProduto.ProductAPI.Utils;

namespace CadastroProduto.ProductAPI.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Value { get; set; }
        public int CategoryId { get; set; }
        public Status Status { get; set; }
    }
}
