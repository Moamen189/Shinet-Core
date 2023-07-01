using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specification
{
    public class ProductWithTypesAndBrandSpecification : BaseSpecification<Product>
    {
        public ProductWithTypesAndBrandSpecification()
        {
            addIncludes(X => X.ProductType);
            addIncludes(X => X.ProductBrand);

        }
    }
}
