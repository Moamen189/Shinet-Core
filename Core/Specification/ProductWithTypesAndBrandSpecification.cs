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
        public ProductWithTypesAndBrandSpecification(ProductSpecParams productParams):base(x =>
            (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search)) &&
            (!productParams.BrandId.HasValue || x.ProductBrandId == productParams.BrandId) &&
            (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId)
            )
        {
            addIncludes(X => X.ProductType);
            addIncludes(X => X.ProductBrand);
            AddOrderBy(x => x.Name);
            ApplyPagging(productParams.PageSize * (productParams.PageIndex - 1) , productParams.PageSize);

            if (!string.IsNullOrEmpty(productParams.Sort))
            {
                switch (productParams.Sort)
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
