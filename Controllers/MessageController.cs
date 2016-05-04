using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Covert_sation_Server.Models;

namespace Covert_sation_Server.Controllers
{
    [Route("api/[controller]")]
    public class MessageController : Controller
    {
        List<Message> messages = new List<Message>();

        public JsonResult Create(int id, string body, ICollection<UserMessage> receivers)
        {
            Message temp = new Message {Id = id, Body = body, Receivers = receivers};
            // create timer
            // timer created here
            // and added to messages
            messages.Add(temp);
            return Json(true);
        }
        
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            // find message by id
            int messageindex = messages.FindIndex(Message => Message.Id == id);
            messages.RemoveAt(messageindex);
        }
        
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
    }
}
