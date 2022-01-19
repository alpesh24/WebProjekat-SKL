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
    public class LigaController:ControllerBase
    {
        public SLContext Context {get; set; }
        
        public LigaController(SLContext context)
        {
            Context = context;
        }

        [Route("Lige")]
        [HttpGet]
        public async Task<ActionResult> Lige()
        {
            try
            {
                var lige = await Context.Lige.ToListAsync();
                foreach (var liga in lige)
                {
                    liga.Timovi = await Context.Timovi.Where(x=> x.LigaID==liga.ID).ToListAsync();
                }
                return Ok(lige);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("DodajLigu/{ime}")]
        [HttpPost]
        public async Task<ActionResult> DodajLigu(string ime)
        {
            if (string.IsNullOrWhiteSpace(ime) || ime.Length > 50)
            {
                return BadRequest("Nevalidni Naziv!");
            }

            try
            {
                Liga liga = new Liga
                {
                    Naziv = ime
                };
                
                Context.Lige.Add(liga);
                await Context.SaveChangesAsync();
                return Ok($"Liga je dodat! ID je: {liga.ID}");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}