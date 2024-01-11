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
    public class CategoryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRepoistoryPattern<Category> _repoistoryPattern;

        public CategoryController( IMapper mapper, IRepoistoryPattern<Category> repoistoryPattern)
        {
            _mapper = mapper;
            _repoistoryPattern = repoistoryPattern;
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory([FromForm]CategoryDto category)
        {
            var cat = _mapper.Map<Category>(category);
            cat = await _repoistoryPattern.Add(cat);
            return Ok(cat);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _repoistoryPattern.GetAll();
            return Ok(categories);
        }
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            
            var category = await _repoistoryPattern.GetById(id);
            return Ok(category);
        }


        [HttpGet("GetByName/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            var category = await _repoistoryPattern.GetByName(a => a.Name == name);
            return Ok(category);
        }
    }
}
