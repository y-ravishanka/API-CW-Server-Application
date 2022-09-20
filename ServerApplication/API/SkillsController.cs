using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerApplication.Data;
using ServerApplication.Model;

namespace ServerApplication.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private Database db = new();
        private Skills c = new();
        private List<Skills> list = new();

        [HttpGet("{nic}")]
        public ActionResult<IEnumerable<Skills>> GetDegree(string nic)
        {
            try
            {
                list = db.GetSkills(nic);
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
                bool t = db.DeleteSkills(id);
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
        public ActionResult SetDegree(Skills ce)
        {
            try
            {
                bool t = db.SetSkills(ce);
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
