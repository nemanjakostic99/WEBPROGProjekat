using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using server.Models;

namespace server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BolnicaController : ControllerBase
    {
        public BolnicaContext Context { get; set; }

        public BolnicaController(BolnicaContext context)
        {
            Context = context;
        }
         [Route("PreuzmiBolnice")]
         [HttpGet]
         public async Task<List<Bolnica>> PreuzmiBolnice()
         {
             return await Context.Bolnice.Include(p => p.Spratovi).ThenInclude(s => s.Kreveti).ThenInclude(d => d.pacijent).ToListAsync();
         }

         [Route("UpisiBolnicu")]
         [HttpPost]
         public async Task UpisiBolnicu([FromBody] Bolnica bolnica)
         {
             Context.Bolnice.Add(bolnica);
             await Context.SaveChangesAsync();
         }

         [Route("IzmeniBolnicu")]
         [HttpPut]
         public async Task IzmeniBolnicu([FromBody] Bolnica bolnica)
         {
            //var staraBolnica = await Context.Bolnice.FindAsync(bolnica.ID);
            //staraBolnica.BrojSpratova = bolnica.BrojSpratova;
            //staraBolnica.BrojSoba = bolnica.BrojSoba;
            //staraBolnica.BrojKrevetaPoSobi = staraBolnica.BrojKrevetaPoSobi;

            Context.Update<Bolnica>(bolnica);
            await Context.SaveChangesAsync();
         }
         [Route("IzbrisiBolnicu/{id}")]
         [HttpDelete]
         public async Task IzbrisiBolnicu(int id)
         {
             var bolnica = await Context.Bolnice.FindAsync(id);
             Context.Remove(bolnica);
             await Context.SaveChangesAsync();
         }
    }
}