using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using System.Threading.Tasks;
using Covert_sation_Server.Models;

namespace Covert_sation_Server.Controllers
{
    [Route("api/[controller]")]
    public class GroupController : Controller
    {
        
        List<Group> groups = new List<Group>{};
        
        // GET: api/values
        [HttpGet]
        public bool CreateGroup([FromBody]string name, [FromBody]ICollection<User> users)
        {
            Group temp = new Group{Name = name, Admin = users.First(), Members = users};
            // Generate group ID
            temp.Id = 1;
            groups.Add(temp);
            return true;
        }


        // GET api/values/5
        [HttpGet("{id}")]
        public void AddMember(int id, int groupId)
        {
            // Get correct group
            int groupindex = groups.FindIndex(Group => Group.Id == groupId);
            // Get the user by id 
            User temp = groups[groupindex].Members.FirstOrDefault(User => User.Id == id);
            groups[groupindex].Members.Add(temp);
        }
        
        public void PromoteMember(int id, int groupId)
        {
            // Get correct group
            int groupindex = groups.FindIndex(Group => Group.Id == groupId);
            // Get the user by id
            User temp = groups[groupindex].Members.FirstOrDefault(User => User.Id == id);
            groups[groupindex].Admin = temp;
        }


        // POST api/values
        [HttpPost]
        public void RemoveMember(int id, int groupId)
        {
            // Get correct group
            int groupindex = groups.FindIndex(Group => Group.Id == groupId);
            // Get user by index
            User temp = groups[groupindex].Members.FirstOrDefault(User => User.Id == id);
            groups[groupindex].Members.Remove(temp);
        }


        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void DeleteGroup(int groupId)
        {
            // Get correct group
            int groupindex = groups.FindIndex(Group => Group.Id == groupId);
            groups.RemoveAt(groupindex);
        }
    }
}
