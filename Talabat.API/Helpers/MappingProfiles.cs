using AutoMapper;
using Talabat.API.DTOs;
using Talabat.DAL.Entities;
//using Talabat.DAL.Entities.identity;

namespace Talabat.API.Helpers
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToDTO>()
                .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
                .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<PictureUrlResolver>());

//            CreateMap<Address, AddressDto>().ReverseMap();

//            CreateMap<CustomerBasketDto, CustomerBasket>();

//            CreateMap<BasketItemDto, BasketItem>();
        }
    }
}
