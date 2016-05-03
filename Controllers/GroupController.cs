using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Covert_sation_Server.Models;

namespace Covert_sation_Server.Controllers
{
    [Route("api/[controller]")]
    public class GroupController : Controller
    {
        [HttpGet]
        public bool Create([FromBody]string name, [FromBody]ICollection<User> users)
        {
            throw new System.NotImplementedException();
        }
        
        [HttpGet("{id}")]
        public string AddMember(int id)
        {
            throw new System.NotImplementedException();
        }
        
        [HttpPost]
        public void RemoveMember([FromBody]string value)
        {
            throw new System.NotImplementedException();
        }

        // PUT api/group/{id}
        [HttpDelete("{id}")]
        public void DeleteGroup(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
