using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerApplication.Data;
using ServerApplication.Model;

namespace ServerApplication.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class DegreeController : ControllerBase
    {
        private Database db = new();
        private Degree c = new();
        private List<Degree> list = new();

        [HttpGet("{nic}")]
        public ActionResult<IEnumerable<Degree>> GetDegree(string nic)
        {
            try
            {
                list = db.GetDegrees(nic);
                if(list.Count == 0)
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
                bool t = db.DeleteDegree(id);
                if(t==true)
                { return Ok(); }
                else
                { return NoContent(); }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public ActionResult SetDegree(Degree ce)
        {
            try
            {
                bool t = db.SetDegree(ce);
                if(t==true)
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
