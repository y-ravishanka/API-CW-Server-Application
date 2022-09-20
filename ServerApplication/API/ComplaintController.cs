using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerApplication.Data;
using ServerApplication.Model;

namespace ServerApplication.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplaintController : ControllerBase
    {
        private Database db = new();
        private Complaint c = new();
        private List<Complaint> list = new();

        [HttpGet]
        [Route("getbynic/{nic}")]
        public ActionResult<IEnumerable<Complaint>> GetComplaints(string nic)
        {
            try
            {
                list = db.GetComplaints(nic);
                if (list.Count == 0)
                { return NoContent(); }
                else
                { return Ok(list); }
            }
            catch (Exception)
            { return BadRequest(); }
        }

        [HttpDelete]
        public ActionResult DeleteCompaint(int id)
        {
            bool t = false;
            try
            {
                t = db.DeleteComplaints(id);
                if(t==true)
                {
                    return Ok();
                }
                else
                { return BadRequest(); }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public ActionResult SetComplaint([FromForm]Complaint ce)
        {
            try
            {
                bool t = db.SetComplaints(ce);
                if(t == true)
                { return Ok();}
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
