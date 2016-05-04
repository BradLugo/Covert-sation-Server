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
        
        // Creates a group for invited users for groupwide messaging
        // name -   desired name of the group. Group will be rejected if name
        //          already exists
        // users -  List of users permitted in the group chat
        // GET: api/values
        [HttpGet]
        public bool CreateGroup([FromBody]string name, [FromBody]ICollection<User> users)
        {
            
            Group temp = new Group{Name = name, Admin = users.First(), Members = users};
            if(groups.FindIndex(Group => Group.Name == temp.Name) != 0)
                return false;
            // Generate group ID
            temp.Id = 1;
            groups.Add(temp);
            return true;
        }

        // Adds a member to a group given by the groupId
        // id -         Id of the User to be added
        // groupId -    groupId of the group to be joined
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
        
        // Promotes another member to the Administrator of the group
        // id -         Id of the User to be promoted. Promotion is rejected
        //              if the User isn't Administrator
        // groupId -    groupId of the group to be promoted in
        public void PromoteMember(int id, int groupId)
        {
            int groupindex = -1;
            // Get correct group
            groupindex = groups.FindIndex(Group => Group.Id == groupId);
            if(groupindex == -1)
                return;
            // Get the user by id
            User temp = groups[groupindex].Members.FirstOrDefault(User => User.Id == id);
            groups[groupindex].Admin = temp;
        }

        // Remove a User from the group given by the groupId
        // id -         Id of the User to be removed. No action is taken
        //              if the user is already not in the group
        // groupId -    groupId of the group to be promoted in
        // POST api/values
        [HttpPost]
        public void RemoveMember(int id, int groupId)
        {
            int groupindex = -1;
            // Get correct group
            groupindex = groups.FindIndex(Group => Group.Id == groupId);
            // Get user by index
            User temp = groups[groupindex].Members.FirstOrDefault(User => User.Id == id);
            groups[groupindex].Members.Remove(temp);
        }

        // Deletes a group
        // groupId -    groupId of the group to be deleted
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
