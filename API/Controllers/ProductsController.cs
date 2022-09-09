using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext _context;

        public ProductsController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Products>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }
        [HttpGet("{id}")] // api/products/3
        public async Task<ActionResult<Products>> GetProduct(int id) => await _context.Products.FindAsync(id);
    }
}