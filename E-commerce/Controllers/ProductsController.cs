using AutoMapper;
using E_commerce.Dtos;
using E_commerce.Interfaces;
using E_commerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private int MaxAllowedImgSize =  1024 * 1024;
        public ProductsController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        [HttpPost]
        public IActionResult AddProduct([FromForm]ProductDto productDto)
        {
            if(productDto.Image.Length > MaxAllowedImgSize)
            {
                return BadRequest("The maximum allowed Image size is 1 MB");
            }    
            var product = _mapper.Map<Product>(productDto);
            using var dataStream = new MemoryStream();
            productDto.Image.CopyTo(dataStream);
            product.Image = dataStream.ToArray();
            product = _unitOfWork.Product.Add(product);
            return Ok(product);
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok( _unitOfWork.Product.GetAll( new[] { "Category" }  ));
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            return Ok( _unitOfWork.Product.GetById( id, new[] { "Category" }));
        }


        [HttpGet("GetByName/{Name}")]
        public  IActionResult GetByName(string Name)
        {
            return Ok( _unitOfWork.Product.GetByName(c => c.Name == Name, new[] { "Category" }));
        }
    }
}
