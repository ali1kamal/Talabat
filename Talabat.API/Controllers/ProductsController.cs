using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.API.DTOs;
using Talabat.API.Errors;
using Talabat.API.Helpers;
using Talabat.BLL.Interfaces;
using Talabat.BLL.Specifications;
using Talabat.DAL.Entities;

namespace Talabat.API.Controllers
{
    [Authorize]
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> productsRepo;
        private readonly IGenericRepository<ProductBrand> brandsRepo;
        private readonly IGenericRepository<ProductType> typesRepo;

        public IMapper Mapper { get; }

        public ProductsController(IGenericRepository<Product> productsRepo, IGenericRepository<ProductBrand> brandsRepo, IGenericRepository<ProductType> typesRepo, IMapper mapper)
        {
            this.productsRepo = productsRepo;
            this.brandsRepo = brandsRepo;
            this.typesRepo = typesRepo;
            Mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<Pagination<ProductToDTO>>> GetProducts([FromQuery ]ProductSpecParam specParam)
        {
            var spec = new ProductWithTypeAndBrandSpecification(specParam);
            var products = await productsRepo.GetAllWithSpecAsync(spec);
            var data = Mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToDTO>>(products);
            var countSpec = new ProductsWithFiltersForCountSpecification(specParam);
            var Count = await productsRepo.CountAsync(countSpec);
            return Ok(new Pagination<ProductToDTO>(specParam.PageIndex, specParam.PageSize,Count, data));
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse),StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductToDTO>> GetProduct(int id)
        {
            var spec = new ProductWithTypeAndBrandSpecification(id);
            var products = await productsRepo.GetByIdWithSpecAsync(spec);
            if (products == null) return NotFound(new ApiResponse(404));
            return Ok(Mapper.Map<Product, ProductToDTO>(products));
        }
        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetBrands()
        {
            var brands = await brandsRepo.GetAllAsync();
            return Ok(brands);
        }
        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetTypes()
        {
            var types = await typesRepo.GetAllAsync();
            return Ok(types);
        }
    }
}
