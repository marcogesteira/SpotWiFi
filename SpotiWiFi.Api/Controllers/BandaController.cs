using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpotiWiFi.Domain.Streaming.Aggregates;
using SpotiWiFi.Repository;

namespace SpotiWiFi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BandaController : ControllerBase
    {
        private SpotiWiFiContext Context { get; set; }

        public BandaController(SpotiWiFiContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetBandas()
        {
            var result = this.Context.Bandas.ToList();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetBandas(Guid id)
        {
            var result = this.Context.Bandas.FirstOrDefault(x => x.Id == id);
            
            if (result == null)
            {
                return NotFound();
            }
            
            return Ok(result);
        }

        [HttpPost]
        public IActionResult SaveBandas([FromBody] Banda banda)
        {
            this.Context.Bandas.Add(banda);
            this.Context.SaveChanges();

            return Created($"/banda/{banda.Id}", banda);
        }
        
    }
}
