using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerApplication.Data;
using ServerApplication.Model;

namespace ServerApplication.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienceController : ControllerBase
    {
        private Database db = new();
        private Experience c = new();
        private List<Experience> list = new();

        [HttpGet("{nic}")]
        public ActionResult<IEnumerable<Experience>> GetDegree(string nic)
        {
            try
            {
                list = db.GetExperience(nic);
                if (list.Count == 0)
                { return NoContent(); }
                else
                { return Ok(list); }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult DeleteDegree(int id)
        {
            try
            {
                bool t = db.DeleteExperience(id);
                if (t == true)
                { return Ok(); }
                else
                { return NotFound(); }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public ActionResult SetDegree(Experience ce)
        {
            try
            {
                bool t = db.SetExperience(ce);
                if (t == true)
                { return Ok(); }
                else
                { return BadRequest(); }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
