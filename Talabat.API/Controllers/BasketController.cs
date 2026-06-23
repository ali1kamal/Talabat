using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using Talabat.API.DTOs;
using Talabat.BLL.Interfaces;
using Talabat.DAL.Entities;

namespace Talabat.API.Controllers
{
    public class BasketController : BaseApiController
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;
        public BasketController(IBasketRepository basketRepository, IMapper mapper)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<CustomerBasket>> GetBasket(string id)
        {
            var basket = await _basketRepository.GetBasketAsync(id);
            return Ok(basket ?? new CustomerBasket(id));
        }

        [HttpPost]
        public async Task<ActionResult<CustomerBasket>> UpdateBasket([FromBody]CustomerBasketDto basket)
        {
            var mappedBasket = _mapper.Map<CustomerBasketDto,CustomerBasket>(basket);
            var customerbasket = await _basketRepository.UpdateBasketAsync(mappedBasket);
            return Ok(customerbasket);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteBasket(string id) 
        {
            /*await _basketRepository.DeleteBasketAsync(id);
            return Ok();*/
            var deleted = await _basketRepository.DeleteBasketAsync(id);
            if (!deleted)
                return NotFound();// Return 404 if the basket was not found

            return NoContent(); // Return 204 No Content if the deletion was successful
        }
    }
}

