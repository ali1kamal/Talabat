//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection.Metadata;
//using System.Text;
//using System.Text.Json;
//using System.Threading.Tasks;
//using Talabat.DAL.Entities;

//namespace Talabat.BLL.Specifications
//{
//    public class ProductWithTypeAndBrandSpecification : BaseSpecification<Product>
//    {
//       public ProductWithTypeAndBrandSpecification(ProductSpecParam specParam) 
//            : base(P=>
//            (string.IsNullOrEmpty(specParam.Search) || P.Name.ToLower().Contains(specParam.Search)) &&
//            (!specParam.TypeId.HasValue || P.ProductTypeId== specParam.TypeId.Value)&&
//            (!specParam.BrandId.HasValue || P.ProductBrandId == specParam.BrandId.Value)
//            )
//       {
//            AddInclude(p => p.ProductBrand);
//            AddInclude(p => p.ProductType);
//            AddOrderBy(p => p.Name);
//            ApplyPaging((specParam.PageIndex - 1) * specParam.PageSize, specParam.PageSize);
//            if (!string.IsNullOrEmpty(specParam.Sort))
//            {
//                switch (specParam.Sort)
//                {
//                    case "priceAsc":
//                        AddOrderBy(p => p.Price);
//                        break;
//                    case "priceDesc":
//                        AddOrderByDescending(p => p.Price);
//                        break;
//                    default:
//                        AddOrderBy(p => p.Name);
//                        break;
//                }
//            }
//        }
//        public ProductWithTypeAndBrandSpecification(int id) : base(p => p.Id == id)
//        {
//                AddInclude(p => p.ProductBrand);
//                AddInclude(p => p.ProductType);
//        }
       
//    }
//}
