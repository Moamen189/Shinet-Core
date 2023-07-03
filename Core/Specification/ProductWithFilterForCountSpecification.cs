using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specification
{
    public class ProductWithFilterForCountSpecification:BaseSpecification<Product>
    {
        public ProductWithFilterForCountSpecification(ProductSpecParams productSpecParams) : base(X => !productSpecParams.BrandId.HasValue || X.ProductBrandId == productSpecParams.BrandId
             && !productSpecParams.TypeId.HasValue || X.ProductTypeId == productSpecParams.TypeId)
        {

        }
    }
}
