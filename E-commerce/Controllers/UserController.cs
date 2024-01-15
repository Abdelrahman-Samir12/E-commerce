using AutoMapper;
using E_commerce.Dtos;
using E_commerce.Helpers;
using E_commerce.Interfaces;
using E_commerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpPost("Registration")]
        public IActionResult Register([FromForm]UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            if (userDto.Role == Role.user)
                user.RoleName = "User";
            else if (userDto.Role == Role.admin)
                user.RoleName = "Admin";
    
            user = _unitOfWork.User.Add(user);

            _unitOfWork.ShoppingCart.CreateNewShoppingCart(user.Id);
            return Ok(user);
        }
        [HttpGet("GetAllUsers")]
        public IActionResult GetAll()
        {
            return Ok(_unitOfWork.User.GetAll());
        }
        [HttpPost("AddProductToCart/{UserId}")]
        public IActionResult AddProductToCart(int UserId, [FromForm] ProductDetalis productDetalis)
        {
            var product = _unitOfWork.Product.GetByName(c => c.Name == productDetalis.Name);
            if (product == null)
            {
                return NotFound($"No Product with name {productDetalis.Name} was found");
            }
            if(productDetalis.Amount > product.Amount)
            {
                return BadRequest("Not available Amount !!");
            }
            else
            {
                product.Amount = productDetalis.Amount;
                var cart = _unitOfWork.ShoppingCart.AddItemToCart(UserId, product);
                return Ok(cart);
            }
        }

    }
}
