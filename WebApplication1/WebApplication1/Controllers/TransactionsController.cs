using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")] //[controller] = Transactions
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        [HttpGet] //Transactions default
        public string Get()
        {
            return "Hoşgeldiniz.";
        }

        [HttpGet]
        [Route("[action]")] //action = Random
        public async Task<IActionResult> Random()
        {            
            return Ok(BackgroundRandomNumberState.RandomNumber); // background task async dir.
        }

        [HttpGet]
        [Route("[action]")] //action = Char
        public async Task<IActionResult> Char()
        {
            return Ok(BackgroundTurkishCharState.TurkishChar.ToString()); // background task async dir.
        }
    }
}
