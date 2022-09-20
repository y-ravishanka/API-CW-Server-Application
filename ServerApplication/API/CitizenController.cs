using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerApplication.Data;
using ServerApplication.Model;

namespace ServerApplication.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitizenController : ControllerBase
    {
        private Database db = new();
        private Citizen c = new();
        private List<Citizen> list = new();
        private Qualification q = new();

        [HttpGet]
        [Route("getalltalents")]
        public ActionResult<IEnumerable<Citizen>> GetCitizens()
        {
            try
            {
                list = db.GetCitizens_all();
                if(list.Count==0)
                { return NoContent(); }
                else
                { return Ok(list); }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("getbynic/{nic}")]
        public ActionResult<Citizen> GetCitizen(string nic)
        {
            c = db.GetCitizen(nic);
            if(c.nic == null)
            { return NotFound(); }
            else
            { return Ok(c); }
        }

        [HttpPost]
        [Route("setcitizen")]
        public ActionResult SetCitizen(Citizen ce)
        {
            bool t = false;
            try
            {
                t = db.SetCitizen(ce);
                if(t==true)
                { return Ok(); }
                else
                { return BadRequest(); }
            }
            catch (Exception e)
            { return BadRequest(); }
        }

        [HttpGet]
        [Route("qualification/{nic}")]
        public ActionResult<Qualification> GetQualification(string nic)
        {
            try
            {
                q = db.GetQualifications(nic);
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

        [HttpGet]
        [Route("getqualificationbyq/{value}")]
        public ActionResult<Qualification> GetQualification_ByQ(string value)
        {
            try
            {
                q = db.GetQualifications_byq(value);
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

        [HttpPost]
        [Route("qualification")]
        public ActionResult SetQualification(string nic, string value)
        {
            try
            {
                bool t = db.SetQualification(nic, value);
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

        [HttpPut]
        [Route("updatequalification")]
        public ActionResult UpdateQualification(string nic, string value)
        {
            try
            {
                bool t = db.UpdateQualification(nic,value);
                if(t==true)
                { return Ok(); }
                else
                { return NotFound(); }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("updateactive")]
        public ActionResult UpdateCitizenActive(string nic, string value)
        {
            try
            {
                bool t = db.UpdateActive(nic, value);
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

        [HttpDelete]
        public ActionResult Delete(string nic, string value)
        {
            try
            {
                bool t = db.UpdateActive(nic, value);
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
    }
}
