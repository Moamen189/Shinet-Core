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
        public ProductWithTypesAndBrandSpecification(ProductSpecParams productSpecParams):base(X => 
            string.IsNullOrEmpty(productSpecParams.Search) || X.Name.ToLower().Contains( productSpecParams.Search) &&
        
             !productSpecParams.BrandId.HasValue || X.ProductBrandId == productSpecParams.BrandId
             && !productSpecParams.TypeId.HasValue || X.ProductTypeId == productSpecParams.TypeId)
        {
            addIncludes(X => X.ProductType);
            addIncludes(X => X.ProductBrand);
            AddOrderBy(x => x.Name);
            ApplyPagging(productSpecParams.PageSize * (productSpecParams.PageIndex - 1) , productSpecParams.PageSize);

            if (!string.IsNullOrEmpty(productSpecParams.Sort))
            {
                switch (productSpecParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(P => P.Price); 
                        break;
                    case "priceDsc":
                        AddOrderByDesending(P => P.Price);
                        break;
                    default: 
                        AddOrderBy(P => P.Name);
                        break;
                }
            }

        }

        public ProductWithTypesAndBrandSpecification(int id):base(x => x.Id == id)
        {
            addIncludes(X => X.ProductType);
            addIncludes(X => X.ProductBrand);
        }
    }
}
