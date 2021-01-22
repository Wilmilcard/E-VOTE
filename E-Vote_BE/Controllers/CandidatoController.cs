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
    public class CandidatoController : ControllerBase
    {

        private readonly AppDbContext context;

        public CandidatoController(AppDbContext con)
        {
            this.context = con;
        }

        [HttpGet]
        public IEnumerable<Candidato> Get()
        {
            return this.context.Candidato.ToList();
        }


        [HttpGet("{id}")]
        public Candidato Get(int id)
        {
            return this.context.Candidato.FirstOrDefault(x => x.Id == id);
        }


        [HttpPost]
        public ActionResult Post([FromBody] Candidato value)
        {
            try
            {
                context.Candidato.Add(value);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Candidato value)
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
            var cand = context.Candidato.FirstOrDefault(p => p.Id == id);
            if (cand != null)
            {
                context.Candidato.Remove(cand);
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
