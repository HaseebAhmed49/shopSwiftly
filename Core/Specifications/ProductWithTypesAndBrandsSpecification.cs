using System;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
	public class ProductWithTypesAndBrandsSpecification: BaseSpecification<Product>
	{
		// Constructor that is using the BaseSpecification No Parameter Constructor
		public ProductWithTypesAndBrandsSpecification()
		{
			AddInclude(x => x.ProductType);
			AddInclude(x => x.ProductBrand);
		}

        // Criteria => base(x => x.Id == id) 
        public ProductWithTypesAndBrandsSpecification(int id)
			: base(x => x.Id == id)
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }
    }
}