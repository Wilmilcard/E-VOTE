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
    public class SufraganteController : ControllerBase
    {
        private readonly AppDbContext context;

        public SufraganteController(AppDbContext con)
        {
            this.context = con;
        }


        [HttpGet]
        public IEnumerable<Sufragante> Get()
        {
            return this.context.Sufragante.ToList();
        }


        [HttpGet("{id}")]
        public Sufragante Get(int id)
        {
            return this.context.Sufragante.FirstOrDefault(x => x.Id == id);
        }


        [HttpPost]
        public ActionResult Post([FromBody] Sufragante value)
        {
            try
            {
                context.Sufragante.Add(value);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Sufragante value)
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
            var suf = context.Sufragante.FirstOrDefault(p => p.Id == id);
            if (suf != null)
            {
                context.Sufragante.Remove(suf);
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
