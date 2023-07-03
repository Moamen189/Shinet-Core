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
        public ProductWithTypesAndBrandSpecification(string sort, int? brandId, int? TypeId):base(X => !brandId.HasValue || X.ProductBrandId == brandId  
             && !TypeId.HasValue || X.ProductTypeId == TypeId  )
        {
            addIncludes(X => X.ProductType);
            addIncludes(X => X.ProductBrand);
            AddOrderBy(x => x.Name);

            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort)
                {
                    case "priceAsc":
                        AddOrderBy(P => P.Price); 
                        break;
                    case "priceDsc":
                        AddOrderByDesending(P => P.Price);
                        break;
                    default: 
                        AddOrderBy(P => P.Name); break;
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
