using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerApplication.Data;
using ServerApplication.Model;

namespace ServerApplication.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private Database db = new();
        private Contact c = new();
        private List<Contact> list = new();

        [HttpGet]
        [Route("getbynic/{nic}")]
        public ActionResult<IEnumerable<Contact>> GetContacts(string nic)
        {
            try
            {
                list = db.GetContacts(nic);
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

        [HttpDelete("{id}")]
        public ActionResult DeleteContact(int id)
        {
            try
            {
                bool t = db.DeleteContacts(id);
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
        public ActionResult SetContact(Contact ce)
        {
            try
            {
                bool t = db.SetContacts(ce);
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
    }
}
