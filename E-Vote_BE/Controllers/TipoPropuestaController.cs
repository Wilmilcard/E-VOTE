using E_Vote_BE.Context;
using E_Vote_BE.Models;
using Microsoft.EntityFrameworkCore;
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
    public class TipoPropuestaController : ControllerBase
    {
        private readonly AppDbContext context;

        public TipoPropuestaController(AppDbContext con)
        {
            this.context = con;
        }

        [HttpGet]
        public IEnumerable<TipoPropuesta> Get()
        {
            return this.context.TipoPropuesta.ToList();
        }


        [HttpGet("{id}")]
        public TipoPropuesta Get(int id)
        {
            return this.context.TipoPropuesta.FirstOrDefault(x => x.Id == id);
        }

        // POST api/<TipoPropuestaController>
        [HttpPost]
        public ActionResult Post([FromBody] TipoPropuesta value)
        {
            try
            {
                context.TipoPropuesta.Add(value);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] TipoPropuesta value)
        {
            if (value.Id == id)
            {
                context.Entry(value).State = EntityState.Modified;
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var tipo = context.TipoPropuesta.FirstOrDefault(p => p.Id == id);
            if (tipo != null)
            {
                context.TipoPropuesta.Remove(tipo);
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
