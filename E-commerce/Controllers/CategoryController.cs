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
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IActionResult AddCategory([FromForm]CategoryDto category)
        {
            var exists =  _unitOfWork.Category.DoesExist(c=> c.Name == category.Name);
            if (!exists)
            {
                var cat = _mapper.Map<Category>(category);
                cat =  _unitOfWork.Category.Add(cat);
                return Ok(cat);
            }
            return BadRequest($"A Category with Name: {category.Name} Already exists");
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var categories =  _unitOfWork.Category.GetAll();
            return Ok(categories);
        }
        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var category =  _unitOfWork.Category.GetById(id);
            if(category is null)
            {
                return NotFound($"No category with ID: {id} was found!!");
            }
            return Ok(category);
        }


        [HttpGet("GetByName/{name}")]
        public IActionResult GetByName(string name)
        {
            var category =  _unitOfWork.Category.GetByName(a => a.Name == name);
            if(category is null)
            {
                return NotFound($"No category with Name: {name} was found!!");
            }
            return Ok(category);
        }
        [HttpGet("GetProductsByCategory/{name}")]
        public IActionResult GetProductsByCategory(string name)
        {
            if ( _unitOfWork.Category.DoesExist(a => a.Name == name))
            {
                return Ok(_unitOfWork.Category.GetProductsByCategory(name)
                    .Select(x => new { x.Id, x.Name, x.Description, x.Price }));
            }
            return NotFound($"No category with Name: {name} was found!!");
        }

    }
}
