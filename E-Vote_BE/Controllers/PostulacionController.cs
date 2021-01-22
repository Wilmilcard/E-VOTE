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
    public class PostulacionController : ControllerBase
    {

        private readonly AppDbContext context;

        public PostulacionController(AppDbContext con)
        {
            this.context = con;
        }

        [HttpGet]
        public IEnumerable<Postulacion> Get()
        {
            return this.context.Postulacion.ToList();
        }


        [HttpGet("{id}")]
        public Postulacion Get(int id)
        {
            return this.context.Postulacion.FirstOrDefault(x => x.Id == id);
        }


        [HttpPost]
        public ActionResult Post([FromBody] Postulacion value)
        {
            try
            {
                context.Postulacion.Add(value);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Postulacion value)
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

        // DELETE api/<PostulacionController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var pos = context.Postulacion.FirstOrDefault(p => p.Id == id);
            if (pos != null)
            {
                context.Postulacion.Remove(pos);
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
