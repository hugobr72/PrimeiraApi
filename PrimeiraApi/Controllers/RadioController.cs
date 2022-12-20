using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrimeiraApi.Data;
using PrimeiraApi.Models;
using PrimeiraApi.NovaPasta2;

namespace PrimeiraApi.Controllers {
    [ApiController]
    [Route("api")]
    public class RadioController : ControllerBase {
        [HttpGet]
        [Route("alarms")]
        public async Task<IActionResult> GetAlarms(
            [FromServices] AppDbContext context
            ) {
            try {
                var radios = await context.Radio.ToListAsync();
                return Ok(radios);
            }catch(Exception ex) {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("alarms")]
        public async Task<IActionResult> PostAlarm(
        [FromServices] AppDbContext context,
        [FromBody] RadioViewModel model
        ) {
            if (!ModelState.IsValid)
                return BadRequest();

            var radio = new ModelRadioManager {
                Cidade = model.Cidade
            };

            try {
                await context.Radio.AddAsync(radio);
                await context.SaveChangesAsync();
                return Ok(radio);

            }catch(Exception ex) {
                return BadRequest(ex.Message);
            }
        }

    }
}
