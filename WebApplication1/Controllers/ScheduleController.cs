/*//בס"ד
using Bl.Api;
using Bl.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServerUi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        IBLSchedule bl;
        public ScheduleController(IBL bl)
        {
            this.bl = bl.Schedule;
        }

        // GET: api/<ScheduleController>
        [Route("GetAll")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(bl.Get());
        }

        // GET api/<ScheduleController>/5

        [HttpGet("GetByCode/{code}")]
        public IActionResult Get(int code)
        {
            return Ok(bl.GetByCode(code));
        }

        [HttpGet("GetById/{id}")]
        public IActionResult Get(string id)
        {
            return Ok(bl.GetById(id));
        }

        [HttpGet("GetByDay/{day}")]
        public IActionResult GetByDay(string day)
        {
            return Ok(bl.GetByDay(day));
        }

        // POST api/<ScheduleController>
        //[Route("Add")]
        [HttpPost("Add")]
        public IActionResult Post([FromBody] BLSchedule value)
        {
            bl.Add(value);
            return Ok(bl.GetById(value.PersonId));

        }

        // PUT api/<ScheduleController>/5
        //[Route("Update")]
        [HttpPut("Update/{code}")]
        public IActionResult Put(int code, [FromBody] BLSchedule value)
        {
            bl.Update(value, code);
            return Ok(bl.GetById(value.PersonId));
        }

        // DELETE api/<ScheduleController>/5

        [HttpDelete("Delete")]
        public IActionResult Delete(int code)
        {
            string x = bl.GetByCode(code).PersonId;
            bl.Delete(code);
            return Ok(bl.GetById(x));
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(string id)
        {
            bl.DeleteById(id);
            return Ok(bl.GetById(id));    
        }
    }
}
*/
//בס"ד
using Bl.Api;
using Bl.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace ServerUi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        IBLSchedule bl;
        public ScheduleController(IBL bl)
        {
            this.bl = bl.Schedule;
        }

        // GET: api/<ScheduleController>
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

        // GET api/<ScheduleController>/5
        [HttpGet("GetByCode/{code}")]
        public async Task<IActionResult> Get(int code)
        {
            try
            {
                var schedule = await bl.GetByCode(code);
                if (schedule == null)
                {
                    return NotFound($"Schedule with code {code} not found");
                }
                return Ok(schedule);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

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

        [HttpGet("GetByDay/{day}")]
        public async Task<IActionResult> GetByDay(string day)
        {
            try
            {
                return Ok(await bl.GetByDay(day));
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST api/<ScheduleController>
        //[Route("Add")]
        [HttpPost("Add")]
        public async Task<IActionResult> Post([FromBody] BLSchedule value)
        {
            try
            {
                await bl.Add(value);
                return Ok(await bl.GetById(value.PersonId));
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT api/<ScheduleController>/5
        //[Route("Update")]
        [HttpPut("Update/{code}")]
        public async Task<IActionResult> Put(int code, [FromBody] BLSchedule value)
        {
            try
            {
                await bl.Update(value, code);
                return Ok(await bl.GetById(value.PersonId));
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE api/<ScheduleController>/5
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int code)
        {
            try
            {
                var schedule = await bl.GetByCode(code);
                if (schedule == null)
                {
                    return NotFound($"Schedule with code {code} not found");
                }
                return Ok(schedule);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await bl.DeleteById(id);
                return Ok(await bl.GetById(id));
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}