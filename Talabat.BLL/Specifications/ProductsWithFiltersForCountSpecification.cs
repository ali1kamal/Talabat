using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.DAL.Entities;

namespace Talabat.BLL.Specifications
{
    public class ProductsWithFiltersForCountSpecification : BaseSpecification<Product>
    {
        public ProductsWithFiltersForCountSpecification(ProductSpecParam specParam)
          : base(P =>
          (string.IsNullOrEmpty(specParam.Search) || P.Name.ToLower().Contains(specParam.Search)) &&
          (!specParam.TypeId.HasValue || P.ProductTypeId == specParam.TypeId.Value) &&
          (!specParam.BrandId.HasValue || P.ProductBrandId == specParam.BrandId.Value)
          )
        {

        }
    }
}
