using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Persistence;
using Microsoft.EntityFrameworkCore;
using Domain;
namespace API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ValuesController : ControllerBase
    {

        private readonly DataContext _dataContext;
        public ValuesController(DataContext context)
        {
            _dataContext = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Value>>> Get()
        {
            var list = await _dataContext.Value.ToListAsync();

            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Value>> Get(int id)
        {
            var value = await _dataContext.Value.FindAsync(id);

            return Ok(value);
        }


    }
}
