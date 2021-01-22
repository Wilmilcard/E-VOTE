using E_Vote_BE.Context;
using E_Vote_BE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public ActionResult Post([FromBody] TipoDoc value)
        {
            try
            {
                context.TipoDoc.Add(value);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] TipoDoc value)
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


        [HttpDelete("{codigo}")]
        public ActionResult Delete(string codigo)
        {
            var prod = context.TipoDoc.FirstOrDefault(p => p.Codigo == codigo);
            if (prod != null)
            {
                context.TipoDoc.Remove(prod);
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
