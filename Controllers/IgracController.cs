using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models;

namespace WP_Liga.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IgracController : ControllerBase
    {
        public SLContext Context {get; set; }
        
        public IgracController(SLContext context)
        {
            Context = context;
        }

        [Route("Preuzmi")]
        [HttpGet]
        public async Task<ActionResult> Preuzmi()
        {
            var igraci = new List<Igrac>();
            try
            {
              igraci = await Context.Igraci.Include(p=>p.Tim).ToListAsync();
            }
             catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok(igraci);
        }

        [Route("DodatiIgraca/{ime}/{prezime}/{godiste}/{visina}/{nazivTima}")]
        [HttpPost]
        public async Task<ActionResult> DodajIgraca(string ime, string prezime, 
        int godiste, int visina, string nazivTima)
        {
            if (string.IsNullOrWhiteSpace(ime) || ime.Length > 50)
            {
                return BadRequest("Nevalidno Ime!");
            }
            if (string.IsNullOrWhiteSpace(prezime) || prezime.Length > 50)
            {
                return BadRequest("Nevalidno Prezime}!");
            }
            if (godiste < 1980 || godiste > 2003)
            {
                return BadRequest("Pogresno Godiste!");
            }

            try
            {
                Tim tim = Context.Timovi.Where(p=> p.Ime == nazivTima).FirstOrDefault();
                Igrac igrac = new Igrac
                {
                    Ime = ime,
                    Prezime = prezime,
                    Godiste = godiste,
                    Visina = visina,
                    Tim = tim
                };
                Context.Igraci.Add(igrac);
                await Context.SaveChangesAsync();
                return Ok($"Igrac je dodat! ID je: {igrac.ID}");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [Route("PromeniIgraca/{ime}/{prezime}/{godiste}/{visina}/{nazivTima}")]
        [HttpPut]
        public async Task<ActionResult> Promeni(string ime, string prezime, int godiste, int visina, string nazivTima)
        {
            if (string.IsNullOrWhiteSpace(ime) || ime.Length > 50)
            {
                return BadRequest("Nevalidno Ime!");
            }
            if (string.IsNullOrWhiteSpace(prezime) || prezime.Length > 50)
            {
                return BadRequest("Nevalidno Prezime}!");
            }
            if (godiste < 1980 || godiste > 2003)
            {
                return BadRequest("Pogresno Godiste!");
            }
            if (string.IsNullOrWhiteSpace(nazivTima) || ime.Length > 50)
            {
                return BadRequest("Nevalidni naziv tima!");
            }
            
            try
            {
                var igrac = Context.Igraci.Where(i => i.Ime == ime  && i.Prezime == prezime).FirstOrDefault();
                Tim tim = Context.Timovi.Where(t => t.Ime == nazivTima).FirstOrDefault();
                if (igrac != null)
                {
                    //igrac.Ime = ime;
                    //igrac.Prezime = prezime;
                    //igrac.Godiste = godiste;
                    igrac.Visina = visina;
                    igrac.Tim = tim;

                    await Context.SaveChangesAsync();
                    return Ok("Uspesno promenjen igrac!");
                }
                else{
                    return BadRequest("Nema takvog igrac");
                }
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

       /*[Route("PromeniFromBody")]
        [HttpPut]
        public async Task<ActionResult> PromeniBody([FromBody] Igrac igrac)
        {
            if (igrac.ID <= 0)
            {
                return BadRequest("Pogresan ID!");
            }
            if (string.IsNullOrWhiteSpace(igrac.Ime) || igrac.Ime.Length > 50)
            {
                return BadRequest("Nevalidno Ime!");
            }
            if (string.IsNullOrWhiteSpace(igrac.Prezime) || igrac.Prezime.Length > 50)
            {
                return BadRequest("Nevalidno Prezime}!");
            }
            if (igrac.Godiste < 1980 || igrac.Godiste > 2003)
            {
                return BadRequest("Pogresno Godiste!");
            }

            try
            {
               // var igracZaPromenu = await Context.Igraci.FindAsync(igrac.ID);
                //igracZaPromenu.Ime = igrac.Ime;
                //igracZaPromenu.Prezime = igrac.Prezime;
                //igracZaPromenu.Godiste = igrac.Godiste;
                //igracZaPromenu.Visina = igrac.Visina;
                //igracZaPromenu.Tim = igrac.Tim;

                Context.Igraci.Update(igrac);

                await Context.SaveChangesAsync();
                return Ok($"Igrac sa ID: {igrac.ID} je uspesno izmenjen!");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }

        }*/

        [Route("IzbrisatiIgraca/{ime}/{prezime}/{visina}")]
        [HttpDelete]
        public async Task<ActionResult> Izbrisi(string ime, string prezime, int visina)
        {
            if (string.IsNullOrWhiteSpace(ime) || ime.Length > 50)
            {
                return BadRequest("Nevalidno Ime!");
            }
            if (string.IsNullOrWhiteSpace(prezime) || prezime.Length > 50)
            {
                return BadRequest("Nevalidno Prezime}!");
            }
            
            
            try
            {
                Igrac igrac = await Context.Igraci.Where(p => p.Ime == ime && p.Prezime == prezime
                && p.Visina == visina).FirstOrDefaultAsync();

                if (igrac != null)
                {
                    Context.Igraci.Remove(igrac);
                    await Context.SaveChangesAsync();
                    return Ok($"Uspesno izbrisan igrac!");
                }
                else{
                    return BadRequest("Nema takvog igrac");
                }
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
