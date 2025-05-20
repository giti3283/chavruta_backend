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
    public class RequestsController : ControllerBase
    {
        IBLRequests bl;
        IBLPerson blp;
        public RequestsController(IBL bl)
        {
            this.bl = bl.Requests;
            this.blp = bl.Person;
        }

        // GET: api/<RequestsController>
        [Route("GetAll")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(bl.Get());
        }

        [HttpGet("GetByCode/{code}")]
        public IActionResult Get(int code)
        {
            return Ok(bl.GetByCode(code));
        }
        // GET api/<RequestsController>/5
        
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

        [HttpGet("GetChavruta/{code}")]
        public IActionResult GetChavruta(int code)
        {
            var x = bl.FindChavruta(code);
            return Ok(x);
                //(bl.FindChavruta(code));
        }


        [HttpGet("SelectChavruta")]
        public IActionResult SelectChavruta(string id,int reqCode,int chaCode,int reqScheduleCode,int chaScheduleCode)
        {
            bl.SelectChavruta(id, reqCode, chaCode, reqScheduleCode, chaScheduleCode);
            return Ok();
        }

        // POST api/<RequestsController>
        [Route("Add")]
        [HttpPost]
        public IActionResult Post([FromBody] BLRequest value)
        {
            bl.Add(value);
            return Ok(blp.GetRequests(value.PersonId)); 
        }

        // PUT api/<RequestsController>/5
        
        [HttpPut("Update/{code}")]
        public IActionResult Put(int code, [FromBody] BLRequest value)
        {
            bl.Update(value, code);
            return Ok(blp.GetRequests(value.PersonId));
        }

        [HttpDelete("Delete/{code}")]
        public IActionResult Delete(int code)
        {
            string x = bl.GetByCode(code).PersonId;
            bl.Delete(code);
            return Ok(blp.GetRequests(x));
        }

        // DELETE api/<RequestsController>/5
        *//*[HttpDelete("Delete/{id}")]
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
    public class RequestsController : ControllerBase
    {
        IBLRequests bl;
        IBLPerson blp;
        public RequestsController(IBL bl)
        {
            this.bl = bl.Requests;
            this.blp = bl.Person;
        }

        // GET: api/<RequestsController>
        [Route("GetAll")]
        [HttpGet]
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

        [HttpGet("GetByCode/{code}")]
        public async Task<IActionResult> Get(int code)
        {
            try
            {
                var request = await bl.GetByCode(code);
                if (request == null)
                {
                    return NotFound($"Request with code {code} not found");
                }
                return Ok(request);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET api/<RequestsController>/5
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

        [HttpGet("GetChavruta/{code}")]
        public async Task<IActionResult> GetChavruta(int code)
        {
            try
            {
                var result = await bl.FindChavruta(code);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /*[HttpGet("SelectChavruta")]
        public async Task<IActionResult> SelectChavruta(string id, int reqCode, int chaCode, int reqScheduleCode, int chaScheduleCode)
        {
            try
            {
                await bl.SelectChavruta(id, reqCode, chaCode, reqScheduleCode, chaScheduleCode);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }*/

        // POST api/<RequestsController>
        [Route("Add")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BLRequest value)
        {
            try
            {
                await bl.Add(value);
                return Ok(await blp.GetRequests(value.PersonId));
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT api/<RequestsController>/5
        [HttpPut("Update/{code}")]
        public async Task<IActionResult> Put(int code, [FromBody] BLRequest value)
        {
            try
            {
                await bl.Update(value, code);
                return Ok(await blp.GetRequests(value.PersonId));
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("Delete/{code}")]
        public async Task<IActionResult> Delete(int code)
        {
            try
            {
                var request = await bl.GetByCode(code);
                if (request == null)
                {
                    return NotFound($"Request with code {code} not found");
                }

                return Ok(request);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE api/<RequestsController>/5
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