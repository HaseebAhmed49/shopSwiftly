using System;
using Core.Entities;

namespace API.DTOs
{
	public class ProductToReturnDTO
	{
        // DTO doesn't contain any business logic
        // Only Getter and Setter involve

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string PictureUrl { get; set; }

        public string ProductType { get; set; }

        public string ProductBrand { get; set; }
    }
}

