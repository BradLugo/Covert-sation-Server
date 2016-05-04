using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using System.Threading.Tasks;
using Covert_sation_Server.Models;

namespace Covert_sation_Server.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        List<User> users = new List<User>();
        
        
        public void Create(string userName, string password, int companyId, string email)
        {
            if(users.Single(User => User.name == userName) != null)
                return;
            // create an Id
            int newid = 1;
            User temp = new User{name = userName, Password = password, CompanyId = companyId, Email = email};
            temp.Id = newid;
            users.Add(temp);
        }
        
        
        // GET: api/user
        [HttpPost]
        public string Login(string userName, string password)
        {
            User Temp = users.Single(User => User.name == userName && User.Password == password);
            if(Temp != null)
            {
                return "Logged in successfully";
            }
            return "Invalid login";
        }
        
        public string AddContact(int id)
        {
            throw new System.NotImplementedException();
        }


        // GET api/user/5
        [HttpGet("{id}")]
        public User GetUser(int id)
        {
            User temp = users.Single(User => User.Id == id);
            if(temp != null)
            {
                return temp;
            }
            return null;
        }
        
        
        public string GetUserName(int id)
        {
            User temp = users.Single(User => User.Id == id);
            return temp.name;
        }
        

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            User temp = users.Single(User => User.Id == id);
            users.Remove(temp);
        }
    }
}
