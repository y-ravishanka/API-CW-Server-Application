using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerApplication.Data;
using ServerApplication.Model;

namespace ServerApplication.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertificateController : ControllerBase
    {
        private Database db = new();
        private Certificate c = new();
        private List<Certificate> list = new();

        [HttpGet("{nic}")]
        public ActionResult<IEnumerable<Certificate>> GetCertificates(string nic)
        {
            try
            { 
                list = db.GetCertificates(nic); 
                if(list.Count == 0)
                {
                    return NotFound();
                }
                else
                { return Ok(list); }
            }
            catch (Exception ex)
            { return NoContent(); }
        }

        [HttpPost]
        [Route("setcetificates")]
        public ActionResult SetCetificates([FromForm]Certificate ce)
        {
            bool t = false;
            try
            {
                t = db.SetCertificate(ce);
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

        [HttpDelete("{id:int}")]
        public ActionResult DeleteCetificate(int id)
        {
            bool t = false;
            try
            {
                t=db.DeleteCertificate(id);
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
