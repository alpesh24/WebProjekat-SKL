using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace WP_Liga.Controllers
{
    [ApiController]
    [Route("controller")]
    public class TimController : ControllerBase
    {
        public SLContext Context {get; set; }
        
        public TimController(SLContext context)
        {
            Context = context;
        }

        [Route("PreuzmiTimove")]
        [HttpGet]
        public async Task<ActionResult> Preuzmi()
        {
            try
            {
                var timovi = await Context.Timovi.Include(p=>p.Igraci).ToListAsync();
                foreach (var tim in timovi)
                {
                    tim.Liga = Context.Lige.Where(x=> x.ID == tim.LigaID).SingleOrDefault();
                }
               
                return Ok(timovi);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [Route("PreuzmiIgraceTima/{idTima}")]
        [HttpGet]
        public async Task<ActionResult> PreuzmiIgrace(int idTima)
        {
            try
            {
                // var tim =  Context.Timovi.Where(x=> x.ID == idTima).SingleOrDefault();

                var igraci = await Context.Igraci.Where(x=> x.TimId == idTima).ToListAsync();

                return Ok(igraci);
                
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }

        }

       /* [Route("DodatiTim")]
        [HttpPost]
        public async Task<ActionResult> DodatiTim([FromBody] Tim tim)
        {
            if (string.IsNullOrWhiteSpace(tim.Ime) || tim.Ime.Length > 50)
            {
                return BadRequest("Nevalidno Ime!");
            }

            try
            {
                Context.Timovi.Add(tim);

                await Context.SaveChangesAsync();
                return Ok($"Tim je dodat! ID je: {tim.ID}");
            }
            catch(Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
        }*/

        [Route("DodajTim/{ime}/{nazivLige}")]
        [HttpPost]
        public async Task<ActionResult> DodajTim(string ime, string nazivLige)
        {
            if (string.IsNullOrWhiteSpace(ime) || ime.Length > 50)
            {
                return BadRequest("Nevalidno Ime!");
            }
            if (string.IsNullOrWhiteSpace(nazivLige) || nazivLige.Length > 50)
            {
                return BadRequest("Nevalidni naziv lige");    
            }

            try
            {
                Liga liga = Context.Lige.Where(l => l.Naziv == nazivLige).FirstOrDefault();
                Tim tim = new Tim
                {
                    Ime = ime,
                    LigaID = liga.ID
                };

                Context.Timovi.Add(tim);

                await Context.SaveChangesAsync();
                return Ok("Uspeseno dodat tim!");

            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /*[Route("PromeniTim")]
        [HttpPut]
        public async Task<ActionResult> PromeniTim([FromBody] Tim tim)
        {
            if (tim.ID <=0)
            {
                return BadRequest("Pogresan ID!");
            }
            if (string.IsNullOrWhiteSpace(tim.Ime) || tim.Ime.Length > 50)
            {
                return BadRequest("Nevalidno Ime!");
            }

            try
            {
                Context.Timovi.Update(tim);
                await Context.SaveChangesAsync();
                return Ok($"Uspesno izmenjen tim! ID je: {tim.ID}");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }*/

        [Route("IzbrsiTim/{ime}")]
        [HttpDelete]
        public async Task<ActionResult> IzbrisatiTim(string ime)
        {
            if (string.IsNullOrWhiteSpace(ime) || ime.Length > 50)
            {
                return BadRequest("Pogrešno ime!");
            }

            try
            {
                var tim = await Context.Timovi.Where(p => p.Ime == ime).FirstOrDefaultAsync();

                if (tim != null)
                {
                    Context.Timovi.Remove(tim);
                    await Context.SaveChangesAsync();
                    return Ok($"Uspesno izbrisan tim! ");
                }
                else{
                    return BadRequest("Nema takovog tima");
                }
                
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}