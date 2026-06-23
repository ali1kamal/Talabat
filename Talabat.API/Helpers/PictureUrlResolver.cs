//using AutoMapper;
//using Talabat.API.DTOs;
//using Talabat.DAL.Entities;

//namespace Talabat.API.Helpers
//{
//    public class PictureUrlResolver : IValueResolver<Product, ProductToDTO, string>
//    {
//        private readonly IConfiguration configuration;

//        public PictureUrlResolver(IConfiguration configuration)
//        {
//            this.configuration = configuration;
//        }
//        public string Resolve(Product source, ProductToDTO destination, string destMember, ResolutionContext context)
//        {
//            if (!string.IsNullOrEmpty(source.PictureUrl))
//                return $"{configuration["ApiUrl"]}{source.PictureUrl}";
//            return null;
//        }
//    }
//}
