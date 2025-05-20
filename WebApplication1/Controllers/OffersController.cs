/*//בס"ד
using Bl.Api;
using Bl.Models;
using Dal.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServerUi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OffersController : ControllerBase
    {
        IBLOffers bl;
        IBLPerson blp;
        public OffersController(IBL bl)
        {
            this.bl = bl.Offers;
            this.blp = bl.Person;
        }

        // GET: api/<OffersController>
        // [Route("GetAll")]
        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            return Ok(bl.Get());
        }

        // GET api/<OffersController>/5
        //[Route("")]
        [HttpGet("GetByCode/{code}")]
        public IActionResult Get(int code)
        {
            return Ok(bl.GetByCode(code));
        }
*//*
        [HttpGet("GetById/{id}")]
        public IActionResult Get(string id)
        {
            return Ok(bl.GetById(id));
        }*//*

        [HttpGet("GetByBook/{book}")]
        public IActionResult GetByBook(string book)
        {
            return Ok(bl.GetByBook(book));
        }

        [HttpGet("GetBySubject/{subject}")]
        public IActionResult GetBySubject(string subject)
        {
            return Ok(bl.GetBySubject(subject));
        }

        // POST api/<OffersController>
        [Route("Add")]
        [HttpPost]
        public IActionResult Post([FromBody] BLOffer value)
        {
            bl.Add(value);
            return Ok(blp.GetRequests(value.PersonId));
        }

        // PUT api/<OffersController>/5
        *//*[Route]*//*
        [HttpPut("UpdateOffer/{code}")]
        public IActionResult UpdateOffer(int code, [FromBody] BLOffer value)
        {
            bl.Update(value, code);
            return Ok(blp.GetRequests(value.PersonId));
        }

        // DELETE api/<OffersController>/5

        [HttpDelete("DeleteOffer/{code}")]
        public IActionResult DeleteOffer(int code)
        {
            string x = bl.GetByCode(code).PersonId;
            bl.Delete(code);
            return Ok(blp.GetRequests(x));
        }

       *//* [HttpDelete("Delete/{id}")]
        public IActionResult Delete(string id)
        {
            bl.DeleteById(id);
            return Ok(bl.Get());
        }*//*
    }
}
*/
//בס"ד
using Bl.Api;
using Bl.Models;
using Dal.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace ServerUi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OffersController : ControllerBase
    {
        IBLOffers bl;
        IBLPerson blp;
        public OffersController(IBL bl)
        {
            this.bl = bl.Offers;
            this.blp = bl.Person;
        }

        // GET: api/<OffersController>
        // [Route("GetAll")]
        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await bl.Get());
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET api/<OffersController>/5
        //[Route("")]
        [HttpGet("GetByCode/{code}")]
        public async Task<IActionResult> Get(int code)
        {
            try
            {
                var offer = await bl.GetByCode(code);
                if (offer == null)
                {
                    return NotFound($"Offer with code {code} not found");
                }
                return Ok(offer);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /*
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                return Ok(await bl.GetById(id));
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        */

        [HttpGet("GetByBook/{book}")]
        public async Task<IActionResult> GetByBook(string book)
        {
            try
            {
                return Ok(await bl.GetByBook(book));
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("GetBySubject/{subject}")]
        public async Task<IActionResult> GetBySubject(string subject)
        {
            try
            {
                return Ok(await bl.GetBySubject(subject));
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST api/<OffersController>
        [Route("Add")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BLOffer value)
        {
            try
            {
                await bl.Add(value);
                return Ok(await blp.GetOffers(value.PersonId));
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT api/<OffersController>/5
        /*[Route]*/
        [HttpPut("UpdateOffer/{code}")]
        public async Task<IActionResult> UpdateOffer(int code, [FromBody] BLOffer value)
        {
            try
            {
                await bl.Update(value, code);
                return Ok(await blp.GetOffers(value.PersonId));
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE api/<OffersController>/5
        [HttpDelete("DeleteOffer/{code}")]
        public async Task<IActionResult> DeleteOffer(int code)
        {
            try
            {
                var offer = await bl.GetByCode(code);
                if (offer == null)
                {
                    return NotFound($"Offer with code {code} not found");
                }

                string personId = offer.PersonId;
                await bl.Delete(code);
                return Ok(await blp.GetOffers(personId));
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /* 
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await bl.DeleteById(id);
                return Ok(await bl.Get());
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        */
    }
}