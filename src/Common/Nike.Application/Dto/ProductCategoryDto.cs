﻿using System.Collections.Generic;
using Nike.Domain.Entities;
using Mapster;

namespace Nike.Application.Dto
{
    public class ProductCategoryDto
    {
        public ProductCategoryDto()
        {
            Products = new List<ProductDto>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public string CreateDate { get; set; }

        public IList<ProductDto> Products { get; set; }

    }
}