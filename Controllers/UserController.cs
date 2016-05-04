using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Covert_sation_Server.Models;

namespace Covert_sation_Server.Controllers
{
    [Route("api/[controller]")]
    public class UserController
    {
        List<User> users = new List<User>();
        
        
        // GET: api/user
        [HttpPost]
        public string Login(string userName, string password)
        {
<<<<<<< Updated upstream
            throw new NotImplementedException();   
=======
            User Temp = users.Single(User => User.name == userName && User.Password == password);
            if(Temp != null)
            {
                return "Logged in successfully";
            }
            return "Invalid login";
>>>>>>> Stashed changes
        }


        // GET api/user/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            User Temp = users.Single(User => User.Id == id);
            if(Temp != null)
            {
                return Temp.name;
            }
            return "value";
        }
        

        // POST api/user
        [HttpPost]
        public void Post([FromBody]string value)
        {
            User Temp = null;
            users.Add(Temp);
        }
        

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
            
        }


        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            User Temp = users.Single(User => User.Id == id);
            users.Remove(Temp);
        }
    }
}
