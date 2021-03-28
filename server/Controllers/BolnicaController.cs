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
             var krevet = await Context.Kreveti.FindAsync(id);
            //  var pacijentUKrevetu = await Context.Pacijenti.FindAsync(krevet.pacijent.ID);
            //  Context.Remove(pacijentUKrevetu);
             Context.Remove(krevet);
             await Context.SaveChangesAsync();
         }

         [Route("IzbrisiSobu/{id}")]
         [HttpDelete]
         public async Task IzbrisiSobu(int id)
         {
            // var nizKreveta=Context.Kreveti.Where(p=>p.soba.ID == id);
            // await nizKreveta.ForEachAsync(s=>{ 
            //     var pacijentUKrevetu = Context.Pacijenti.FindAsync(s.pacijent.ID);
            //     Context.Remove(pacijentUKrevetu);
            //     Context.Remove(s); 
            // });
            // var soba = await Context.Sobe.FindAsync(id);
            var soba = await Context.Sobe.FindAsync(id);
            Context.Remove(soba);
            await Context.SaveChangesAsync();
         }

         [Route("IzbrisiSprat/{id}")]
         [HttpDelete]
         public async Task IzbrisiSprat(int id)
         {
             var sprat = await Context.Spratovi.FindAsync(id);
             
            //  var nizSoba = Context.Sobe.Where(s=>s.sprat.ID==id);
             
            //  await nizSoba.ForEachAsync(s=>{
            //     var nizKreveta=Context.Kreveti.Where(p=>p.soba.ID == s.ID);
            //     nizKreveta.ForEachAsync(t=>{ 
            //     var pacijentUKrevetu = Context.Pacijenti.FindAsync(t.pacijent.ID);
            //     if(pacijentUKrevetu!=null)
            //     Context.Remove(pacijentUKrevetu);
            //     Context.Remove(t); 
            // });
            //     Context.Remove(s);
            // });
            //     Context.Remove(sprat);
            Context.Remove(sprat);
            await Context.SaveChangesAsync();
         }

    

         [Route("IzbrisiBolnicu/{id}")]
         [HttpDelete]
         public async Task IzbrisiBolnicu(int id)
         {
             var bolnica = Context.Bolnice.Include(p => p.spratovi).ThenInclude(p => p.sobe).ThenInclude(p => p.Kreveti).ThenInclude(p => p.pacijent).Where(p => p.ID == id).FirstOrDefault();

            //  List<int> nizSpratovaID = new List<int>();
            //  List<int> nizSobaID = new List<int>();
            //  List<int> nizKrevetaID = new List<int>();
            //  List<int> nizPacijenataID = new List<int>();
             
            //  var nizSpratova=Context.Spratovi.Where(p => p.bolnica.ID == id);

            //  await nizSpratova.ForEachAsync(p => nizSpratovaID.Add(p.ID));

            //  nizSpratovaID.ForEach(async p => {
            //      var nizSoba = Context.Sobe.Where(s => s.sprat.ID == p);
            //      await nizSoba.ForEachAsync(s => nizSobaID.Add(s.ID));
            //  });

            //  nizSobaID.ForEach(async p => {
            //      var nizKreveta = Context.Kreveti.Where(s => s.soba.ID == p);
            //      await nizKreveta.ForEachAsync(s => nizKrevetaID.Add(s.ID));
            //  });

            //  nizKrevetaID.ForEach(async p => {
            //      var nizPacijenata = Context.Pacijenti.Where(s => s.krevet.ID == p);
            //      await nizPacijenata.ForEachAsync(s => nizKrevetaID.Add(s.ID));
            //  });

            //  nizPacijenataID.ForEach(async p => {
            //      var pacijent = await Context.Pacijenti.FindAsync(p);
            //      Context.Remove(pacijent);
            //  });
            //  await Context.SaveChangesAsync();

            //  nizKrevetaID.ForEach(async p => {
            //      var krevet = await Context.Kreveti.FindAsync(p);
            //      Context.Remove(krevet);
            //  });
            //  await Context.SaveChangesAsync();

            //  nizSobaID.ForEach(async p => {
            //      var soba = await Context.Sobe.FindAsync(p);
            //      Context.Remove(soba);
            //  });
            //  await Context.SaveChangesAsync();

            //  nizSpratovaID.ForEach(async p => {
            //      var sprat = await Context.Spratovi.FindAsync(p);
            //      Context.Remove(sprat);
            //  });
            //  await Context.SaveChangesAsync();
             
            //  Context.Remove(bolnica);


            // //  await nizSpratova.ForEachAsync(p => {
            // //      nizSpratovaID.Add(p.ID);
            // //      var nizSoba=Context.Sobe.Where(s => s.sprat.ID == p.ID);
            // //      nizSoba.ForEachAsync(t => {
            // //          nizSobaID.Add(t.ID);
            // //          var nizKreveta=Context.Kreveti.Where(k => k.soba.ID == t.ID);
            // //          nizKreveta.ForEachAsync(nk => {
            // //              nizKrevetaID.Add(nk.ID);
            // //              var nizPacijenata=Context.Pacijenti.Where(pacijent => pacijent.krevet.ID == nk.ID);
            // //              nizPacijenata.ForEachAsync(np => nizPacijenataID.Add(np.ID));
            // //          });
            // //      });
            // //  });
             

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