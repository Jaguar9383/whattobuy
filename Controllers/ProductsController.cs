using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WhatToBuy.Context;

namespace WhatToBuy
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly WhatToBuyContext _context;
        public ProductsController(WhatToBuyContext context)
        {
            _context = context;
        }

        [HttpGet("list/{id}")]
        public IActionResult Products(Guid id)
        {
            return Ok(_context.Products.Where(x => x.ListId == id).OrderBy(x => x.IsChecked));
        }

        [HttpPost("{listId}")]
        public IActionResult Add([FromBody] Product product, Guid listId)
        {
            var listDb = _context.Lists.FirstOrDefault(x => x.Id == listId);
            if(listDb == null)
            {
                return BadRequest();
            }
            else{
                product.ListId = listDb.Id;
                _context.Add(product);
                _context.SaveChanges();
                return Ok();
            }
        }

        [HttpPost("check")]
        public IActionResult Check([FromBody] Product product)
        {
            if(product != null)
            {
                var productDb = _context.Products.FirstOrDefault(x => x.Id == product.Id);
                productDb.IsChecked = !productDb.IsChecked;

                _context.Update(productDb);
                _context.SaveChanges();
                return Ok();
            }
            else{
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var productDb = _context.Products.FirstOrDefault(x => x.Id == id);
            if(productDb != null)
            {
                _context.Remove(productDb);
                _context.SaveChanges();
                return Ok();
            }
            else{
                return BadRequest();
            }
        }
    }
}