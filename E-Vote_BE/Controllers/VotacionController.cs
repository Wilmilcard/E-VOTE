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
    public class VotacionController : ControllerBase
    {
        private readonly AppDbContext context;

        public VotacionController(AppDbContext con)
        {
            this.context = con;
        }

        [HttpGet]
        public IEnumerable<Votacion> Get()
        {
            return this.context.Votacion.ToList();
        }


        [HttpGet("{id}")]
        public Votacion Get(int id)
        {
            return this.context.Votacion.FirstOrDefault(x => x.Id == id);
        }


        [HttpPost]
        public ActionResult Post([FromBody] Votacion value)
        {
            try
            {
                context.Votacion.Add(value);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

    }
}
