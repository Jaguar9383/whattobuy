using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WhatToBuy.Context;

namespace WhatToBuy
{
    [ApiController]
    [Route("api/[controller]")]
    public class ListsController : ControllerBase
    {
        private readonly WhatToBuyContext _context;
        private readonly IMapper _mapper;

        public ListsController(WhatToBuyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Lists()
        {
            return Ok(_mapper.Map<List<ListDto>>(_context.Lists.Include(x => x.Products)));
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody]ToBuyList list)
        {
            if(list.Name != "")
            {
                _context.Add(list);
                _context.SaveChanges();
                return Ok();
            }
            else return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var listDb = _context.Lists.FirstOrDefault(x => x.Id == id);
            if(listDb != null)
            {
                _context.Lists.Remove(listDb);
                _context.SaveChanges();
            }
            return Ok();
        }
    }
}