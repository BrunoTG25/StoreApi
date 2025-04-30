using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using StoreApi.Interfaces;
using StoreApi.Models;

namespace StoreApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        public ProductController(IProductService service) 
        {
            _service = service;
        }
        [HttpGet]
    
        public async Task<ActionResult<List<Product>>> GetAll()
        {
        var product = await _service.GetAllAsync();
            return Ok(product);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            var product = await _service.GetByIdAsync(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Product product)
        {
            await _service.AddAsync(product);
            return CreatedAtAction(nameof (GetById), new {id = product.Id}, product);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update (int id, Product product)
        {   
            if(id != product.Id) return BadRequest("el id no coincide");
            await _service.UpdateAsync(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete (int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }



    }


}
