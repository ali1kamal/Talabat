
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Security.Claims;
using Talabat.API.DTOs;
using Talabat.API.Errors;
//using Talabat.API.Exetentions;
using Talabat.BLL.Interfaces;
using Talabat.DAL.Entities.identity;
using Talabat.DAL.identity.Migrations;

namespace Talabat.API.Controllers
{

    public class AccountController : BaseApiController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        //private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, /*ITokenService tokenService,*/ IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            //_tokenService = tokenService;
            _mapper = mapper;
        }
        [HttpPost("Login")]
        public async Task<ActionResult<UserDto>> login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null)
                return Unauthorized(new ApiResponse(401));
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (!result.Succeeded)
                return Unauthorized(new ApiResponse(401));
            return Ok(new UserDto
            {
                DisplayName = user.DisplayName,
                Email = user.Email,
               /* Token = await _tokenService.GetToken(user, _userManager)*/
            });
        }
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            /*if (CheckEmailExist(registerDto.Email).Result.Value)
                return BadRequest(new ApiValdetionResponse() { Errors = new[] { "this email is already exist" } });*/
            var user = new AppUser()
            {
                Email = registerDto.Email,
                UserName = registerDto.Email.Split("@")[0],
                DisplayName = registerDto.DisplayName,
                PhoneNumber = registerDto.PhoneNumber,
                Address = new Address()
                {
                    FirstName = registerDto.FirstName,
                    LastName = registerDto.LastName,
                    City = registerDto.City,
                    Country = registerDto.Country,
                    Street = registerDto.Street,
                    ZipCode = registerDto.ZipCode
                }
            };
            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded)
                return BadRequest(new ApiResponse(400));
            return Ok(new UserDto
            {
                DisplayName = user.DisplayName,
                Email = user.Email,
                /*Token = await _tokenService.GetToken(user, _userManager)*/
            });
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<UserDto>> CurrentUser()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);

            var user = await _userManager.FindByEmailAsync(email);

            return Ok(new UserDto()
            {
                Email = user.Email,
                DisplayName = user.DisplayName
            });
        }
/*
        [Authorize]
        [HttpGet("address")]
        public async Task<ActionResult<AddressDto>> GetUserAdress()
        {
            var user = await _userManager.FindUserWithAddressByEmailAsync(User);
            return Ok(_mapper.Map<Address, AddressDto>(user.Address));
        }

        [Authorize]
        [HttpPut("address")]
        public async Task<ActionResult<AddressDto>> UpdateUserAddress([FromQuery] AddressDto newaddress)
        {
            var user = await _userManager.FindUserWithAddressByEmailAsync(User);
            user.Address = _mapper.Map<AddressDto, Address>(newaddress);
            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded) return BadRequest(new ApiValdetionResponse { Errors = new[] { "an error Occured while Updating address" } });
            return Ok(newaddress);
        }

        [HttpGet("emailexist")]
        public async Task<ActionResult<bool>> CheckEmailExist(string email)
        {
            return await _userManager.FindByEmailAsync(email) != null;
        }
*/
    }
}
