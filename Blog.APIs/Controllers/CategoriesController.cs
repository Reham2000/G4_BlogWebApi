using Blog.Core.DTos;
using Blog.Core.Interfaces;
using Blog.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.APIs.Controllers
{
    [Route("api/[controller]")] // URL
    // Root URL => https://localhost:7018
    // Base URL => Root url + Route => https://localhost:7018/api/Categories
    // Spitial URL =>  ??
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        // DI
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // Get All Categories
        [HttpGet] // https://localhost:7018/api/Categories
        public async Task<IActionResult> GetAll()
        {
            try
            {
                // get all categories 
                var Categories = await _categoryService.GetAllAsync();
                // check if categories exist
                if(Categories == null || !Categories.Any())
                {
                    return NotFound(new
                    {
                        StatusCode = StatusCodes.Status404NotFound,
                        Message = "No Categories Found",
                        Data = new List<Category>()
                    }); //404
                }
                // return response
                return Ok(new
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Categories Retrived Successfully!",
                    Data = Categories
                }); // 200
            }catch(Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = "An Error Ocurred While Retriving Categories",
                    Error = ex.Message
                }); //400
            }
        }

        [HttpGet("{id}")] // https://localhost:7018/api/Categories/{id}
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var Category  = await _categoryService.GetByIdAsync(id);
                if (Category is null)
                    return NotFound(new
                    {
                        StatusCode = StatusCodes.Status404NotFound,
                        Message = $"Category With Id {id} Not Found"
                    });
                return Ok(new
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Category Retrived Successfully",
                    Data = Category
                });
            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "An Error Ocurred While Retriving Categories",
                    Error = ex.Message
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create (CategoryDto categoryDto)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(new
                    {
                        StatusCode = StatusCodes.Status400BadRequest,
                        Message = "Invalid Cateegory Data",
                        Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)
                    });
                }
                var Category = new Category
                {
                    Name = categoryDto.Name,
                };
                await _categoryService.CreateAsync(Category);
                return StatusCode(StatusCodes.Status201Created, new
                {
                    StatusCode = StatusCodes.Status201Created,
                    Message = "Category Created Successfully",

                });

            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "An Error Ocurred While Creating Categories",
                    Error = ex.Message
                });
            }
        }
    }
}
