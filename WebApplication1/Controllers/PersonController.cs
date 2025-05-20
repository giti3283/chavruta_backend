/*//בס"ד
using Bl.Api;
using Bl.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServerUi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        IBLPerson bl;
        public PersonController(IBL bl)
        {
            this.bl = bl.Person;
        }

        // GET: api/<PersonController>
        [Route("GetAll")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(bl.Get());
        }

        // GET api/<PersonController>/5
        //[Route("GetById")]
        [HttpGet("GetById/{id}")]
        public IActionResult Get(string id)
        {
            return Ok(bl.GetById(id));
        }

        [HttpGet("GetOffers/{id}")]
        public IActionResult GetOffers(string id)
        {
            return Ok(bl.GetOffers(id));
        }


        [HttpGet("GetRequests/{id}")]
        public IActionResult GetRequests(string id)
        {
            return Ok(bl.GetRequests(id));
        }


        // POST api/<PersonController>
        *//*[Route("Add")]
        [HttpPost]
        public IActionResult Post([FromBody] BLPerson value)
        {
            bl.Add(value);
            return Ok(bl.Get());
        }*//*
        [Route("Add")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BLPerson value)
        {
            // הוספת await לפני קריאה לפונקציה אסינכרונית
            await bl.Add(value);
            return Ok(bl.Get());
        }

        // PUT api/<PersonController>/5
        //[Route("Update")]
        [HttpPut("Update/{id}")]
        public IActionResult Put(string id, [FromBody] BLPerson value)
        {
            bl.Update(value, id);
            return Ok(bl.GetById(id));
        }

        // DELETE api/<PersonController>/5
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(string id)
        {
            bl.Delete(id);
            return Ok(bl.Get());
        }
    }
}
*/
//בס"ד
using Bl.Api;
using Bl.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace ServerUi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        IBLPerson bl;
        public PersonController(IBL bl)
        {
            this.bl = bl.Person;
        }

        // GET: api/<PersonController>
        [Route("GetAll")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await bl.Get());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<PersonController>/5
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                return Ok(await bl.GetById(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetOffers/{id}")]
        public async Task<IActionResult> GetOffers(string id)
        {
            try
            {
                return Ok(await bl.GetOffers(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetRequests/{id}")]
        public async Task<IActionResult> GetRequests(string id)
        {
            try
            {
                return Ok(await bl.GetRequests(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<PersonController>
        [Route("Add")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BLPerson value)
        {
            try
            {
                // הוספת await לפני קריאה לפונקציה אסינכרונית
                await bl.Add(value);
                return Ok(await bl.Get());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<PersonController>/5
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] BLPerson value)
        {
            try
            {
                await bl.Update(value, id);
                return Ok(await bl.GetById(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/<PersonController>/5
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await bl.Delete(id);
                return Ok(await bl.Get());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}