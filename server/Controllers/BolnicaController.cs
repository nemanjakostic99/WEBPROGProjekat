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
             return await Context.Bolnice.Include(p => p.spratovi).ThenInclude(a => a.sobe).ThenInclude(s => s.Kreveti).ThenInclude(d => d.pacijent).ToListAsync();
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




        // [Route("UpisiPacijenta")]
        // [HttpPost]
        // public async Task UpisiPacijenta([FromBody] Pacijent pacijent)
        // {

        // }

        [Route("IzmeniPacijenta/{id}/{ime}/{prezime}")]
         [HttpPut]
         public async Task IzmeniPacijenta(int id, string ime, string prezime)
         {
            //var staraBolnica = await Context.Bolnice.FindAsync(bolnica.ID);
            //staraBolnica.BrojSpratova = bolnica.BrojSpratova;
            //staraBolnica.BrojSoba = bolnica.BrojSoba;
            //staraBolnica.BrojKrevetaPoSobi = staraBolnica.BrojKrevetaPoSobi;
            var pac = await Context.Pacijenti.FindAsync(id);
            pac.Ime = ime;
            pac.Prezime = prezime;

            Context.Update<Pacijent>(pac);
            await Context.SaveChangesAsync();
         }


        [Route("IzmeniPacijenta2/{id}")]
         [HttpPut]
         public async Task IzmeniPacijenta2(int id, [FromBody] Pacijent pacijent)
         {
            //var staraBolnica = await Context.Bolnice.FindAsync(bolnica.ID);
            //staraBolnica.BrojSpratova = bolnica.BrojSpratova;
            //staraBolnica.BrojSoba = bolnica.BrojSoba;
            //staraBolnica.BrojKrevetaPoSobi = staraBolnica.BrojKrevetaPoSobi;
            var pac = await Context.Pacijenti.FindAsync(id); //pacijent.ID

            pac.Ime = pacijent.Ime;
            pac.Prezime = pacijent.Prezime;
            pac.Dijeta = pacijent.Dijeta;
            pac.Dijagnoza = pacijent.Dijagnoza;
            

            Context.Update<Pacijent>(pac);
            await Context.SaveChangesAsync();
         }

        [Route("IzbrisiPacijenta/{idPacijenta}")]
        [HttpDelete]
        public async Task IzbrisiPacijenta(int idPacijenta)
         {
             var pacijent = await Context.Pacijenti.FindAsync(idPacijenta);
             Context.Remove(pacijent);
             await Context.SaveChangesAsync();
         }
         [Route("IzbrisiKrevet/{id}")]
         [HttpDelete]
         public async Task IzbrisiKrevet(int id)
         {
             var krevet = Context.Kreveti.Include(p => p.pacijent).Where(p => p.ID == id).FirstOrDefault();
             Context.Remove(krevet);
             await Context.SaveChangesAsync();
         }

         [Route("IzbrisiSobu/{id}")]
         [HttpDelete]
         public async Task IzbrisiSobu(int id)
         {
            var soba = Context.Sobe.Include(p => p.Kreveti).ThenInclude(p => p.pacijent).Where(p => p.ID == id).FirstOrDefault();
            Context.Remove(soba);
            await Context.SaveChangesAsync();
         }

         [Route("IzbrisiSprat/{id}")]
         [HttpDelete]
         public async Task IzbrisiSprat(int id)
         {
            var sprat = Context.Spratovi.Include(p => p.sobe).ThenInclude(p => p.Kreveti).ThenInclude(p => p.pacijent).Where(p => p.ID == id).FirstOrDefault();
            Context.Remove(sprat);
            await Context.SaveChangesAsync();
         }

    

         [Route("IzbrisiBolnicu/{id}")]
         [HttpDelete]
         public async Task IzbrisiBolnicu(int id)
         {
             var bolnica = Context.Bolnice.Include(p => p.spratovi).ThenInclude(p => p.sobe).ThenInclude(p => p.Kreveti).ThenInclude(p => p.pacijent).Where(p => p.ID == id).FirstOrDefault();
             Context.Remove(bolnica);
             await Context.SaveChangesAsync();
         }

         [Route("UpisiPacijenta/{idKreveta}")]
         [HttpPost]
         public async Task<IActionResult> UpisiPacijenta(int idKreveta, [FromBody] Pacijent pacijent)
         {
            var krevet = await Context.Kreveti.FindAsync(idKreveta);
            pacijent.krevet = krevet;

            Context.Pacijenti.Add(pacijent);
            await Context.SaveChangesAsync();
            return Ok();
         }     
    
         

         [Route("UpisiKrevet/{idSobe}")]
         [HttpPost]
         public async Task<IActionResult> UpisiKrevet(int idSobe, [FromBody] Krevet krevet)
         {
             var soba = await Context.Sobe.FindAsync(idSobe);
             krevet.soba = soba;

             Context.Kreveti.Add(krevet);
             await Context.SaveChangesAsync();
             return Ok();
         }

         [Route("UpisiSobu/{idSprata}")]
         [HttpPost]
         public async Task<IActionResult> UpisiSobu(int idSprata, [FromBody] Soba soba)
         {
             var sprat = await Context.Spratovi.FindAsync(idSprata);
             soba.sprat = sprat;

             Context.Sobe.Add(soba);
             await Context.SaveChangesAsync();
             return Ok();
         }

         [Route("UpisiSprat/{idBolnice}")]
         [HttpPost]
         public async Task<IActionResult> UpisiSobu(int idBolnice, [FromBody] Sprat sprat)
         {
             var bolnica = await Context.Bolnice.FindAsync(idBolnice);
             sprat.bolnica = bolnica;

             Context.Spratovi.Add(sprat);
             await Context.SaveChangesAsync();
             return Ok();
         }
    }
}


//         [Route("UpisLokacije/{idVrta}")]
//         [HttpPost]
//         // Upis može takođe da se vrši preko FormData, tako što će atribut da bude [FromForm]
//         // Aplikacija nema formu, tako da je ovde korišćen FromBody, ali je jednostavnije koristiti FormData.

//         public async Task<IActionResult> UpisiLokaciju(int idVrta, [FromBody] Lokacija lok)
//         {
//             var vrt = await Context.Vrtovi.FindAsync(idVrta);
//             lok.Vrt = vrt;

//             if (Context.Lokacije.Any(p => p.Vrsta == lok.Vrsta && (p.X != lok.X || p.Y != lok.Y)))
//             {
//                 var xy = Context.Lokacije.Where(p => p.Vrsta == lok.Vrsta).FirstOrDefault();
//                 return BadRequest(new { X = xy?.X, Y = xy?.Y });
//             }

//             var thatLok = Context.Lokacije.Where(p => p.X == lok.X && p.Y == lok.Y).FirstOrDefault();

//             if (thatLok != null)
//             {
//                 if (thatLok.MaxKapacitet < thatLok.Kapacitet + lok.Kapacitet)
//                 {
//                     return StatusCode(406);
//                 }
//                 else if (thatLok.Vrsta != lok.Vrsta)
//                 {
//                     return StatusCode(406);
//                 }
//                 else
//                 {
//                     thatLok.Kapacitet += lok.Kapacitet;
//                     await Context.SaveChangesAsync();
//                     return Ok();
//                 }
//             }

//             if ((thatLok != null && thatLok.Kapacitet == 0) || thatLok == null)
//             {
//                 Context.Lokacije.Add(lok);
//                 await Context.SaveChangesAsync();
//                 return Ok();
//             }
//             else
//             {
//                 return StatusCode(406);
//             }
//         }
//     }
// }