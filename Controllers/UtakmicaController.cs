using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace WP_Liga.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UtakmicaController:ControllerBase
    {
        public SLContext Context {get; set; }
        
        public UtakmicaController(SLContext context)
        {
            Context = context;
        }

        [Route("Utakmice")]
        [HttpGet]
        public async Task<ActionResult> Utakmice()
        {
            try
            {
                return Ok(await Context.Utakmice.Select(p=>
                new
                {
                    ID = p.ID,
                    Tim1 = p.Tim1.Ime,
                    Tim2 = p.Tim2.Ime,
                    Rezultat1 = p.Rezultat1,
                    Rezultat2 = p.Rezultat2
                }).ToListAsync());
                
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("DodajUtakmicu/{naziv1}/{naziv2}/{rez1}/{rez2}")]
        [HttpPost]
        public async Task<ActionResult> DodajUtakmicu(string naziv1, string naziv2, int rez1, int rez2)
        {
            Utakmica utakmica = new Utakmica();

            var klub1=Context.Timovi.Where(p=>p.Ime==naziv1).FirstOrDefault();

            if(klub1!=null)
            {
                utakmica.Tim1=klub1;
            }
            else
            {
                return BadRequest("Ovaj klub ne postoji!");
            }

            var klub2=Context.Timovi.Where(p=>p.Ime==naziv2).FirstOrDefault();

            if(klub2!=null)
            {
                utakmica.Tim2=klub2;
            }
            else
            {
                return BadRequest("Ovaj klub ne postoji!");
            }

            utakmica.Rezultat1=rez1;
            utakmica.Rezultat2=rez2;

            try
            {
                Context.Utakmice.Add(utakmica);
                await Context.SaveChangesAsync();
                return Ok($"Utakmica je dodata!ID je: {utakmica.ID}");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /*[Route("IzmeniUtakmicu")]
        [HttpPut]
        public async Task<ActionResult> PromeniUtakmicu([FromBody] Utakmica utakmica)
        {
            if (utakmica.ID <= 0)
            {
                return BadRequest("Pogresan Id!");
            }
            try
            {
                Context.Utakmice.Update(utakmica);
                await Context.SaveChangesAsync();
                return Ok($"Utakmica sa ID: {utakmica.ID} je uspesno promenjena!");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }*/

       /* [Route("IzbrsiUtakmicu/{id}")]
        [HttpDelete]
        public async Task<ActionResult> IzbrisiUtakmicu(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Pogresan ID!");
            }

            try
            {
                var utakmica = await Context.Utakmice.FindAsync(id);
                Context.Utakmice.Remove(utakmica);
                await Context.SaveChangesAsync();
                return Ok("Uspesno obrisana utakmica!");

            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }*/
    }
}