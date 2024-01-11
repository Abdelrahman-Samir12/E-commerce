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
        private readonly IRepoistoryPattern<Product> _repoistoryPattern;

        public ProductsController(IMapper mapper, IRepoistoryPattern<Product> repoistoryPattern)
        {
            _mapper = mapper;
            _repoistoryPattern = repoistoryPattern;
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromForm]ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            using var dataStream = new MemoryStream();
            await productDto.Image.CopyToAsync(dataStream);
            product.Image = dataStream.ToArray();
            product = await _repoistoryPattern.Add(product);
            return Ok(product);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _repoistoryPattern.GetAll( new[] { "Category" }  ));
           //    return Ok(_repoistoryPattern.test());
        }


        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _repoistoryPattern.GetById( id, new[] { "Category" }));
        }


        [HttpGet("GetByName/{Name}")]
        public async Task<IActionResult> GetByName(string Name)
        {
            return Ok(await _repoistoryPattern.GetByName(c => c.Name == Name, new[] { "Category" }));
        }
    }
}
