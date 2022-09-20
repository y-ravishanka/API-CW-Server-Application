using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerApplication.Data;
using ServerApplication.Model;

namespace ServerApplication.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiplomaController : ControllerBase
    {
        private Database db = new();
        private Diploma c = new();
        private List<Diploma> list = new();

        [HttpGet("{nic}")]
        public ActionResult<IEnumerable<Diploma>> GetDegree(string nic)
        {
            try
            {
                list = db.GetDiplomas(nic);
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
                bool t = db.DeleteDiploma(id);
                if (t == true)
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
        public ActionResult SetDegree(Diploma ce)
        {
            try
            {
                bool t = db.SetDiploma(ce);
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
