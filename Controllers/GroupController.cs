using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Covert_sation_Server.Models;
using System.Linq;

namespace Covert_sation_Server.Controllers
{
    [Route("api/[controller]")]
    public class GroupController : Controller
    {
        
        List<Group> groups = new List<Group>{};
        
        // GET: api/values
        [HttpGet]
        public bool Create([FromBody]string name, [FromBody]ICollection<User> users)
        {
            throw new System.NotImplementedException();
            Group Temp = new Group{Name = name, Admin = users.First(), Members = users};
            return true;
        }


        // GET api/values/5
        [HttpGet("{id}")]
        public string AddMember(int id)
        {
            throw new System.NotImplementedException();
        }


        // POST api/values
        [HttpPost]
        public void RemoveMember([FromBody]string value)
        {
            throw new System.NotImplementedException();
        }


        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void DeleteGroup(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
