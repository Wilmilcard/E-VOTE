using E_Vote_BE.Context;
using E_Vote_BE.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace E_Vote_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDocController : ControllerBase
    {
        private readonly AppDbContext context;

        public TipoDocController(AppDbContext con)
        {
            this.context = con;
        }

        [HttpGet]
        public IEnumerable<TipoDoc> Get()
        {
            return this.context.TipoDoc.ToList();
        }

        [HttpGet("{codigo}")]
        public TipoDoc Get(string codigo)
        {
            return this.context.TipoDoc.FirstOrDefault(x => x.Codigo == codigo);
        }


        [HttpPost]
        public void Post([FromBody] string value)
        {
        }


        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
