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
        
        // Creates a new User
        // userName -   User's username
        // password -   User's password
        // companyId -  User's companyId
        // email -      User's email
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
        
        // Checks username and password 
        // userName -   User's username
        // password -   User's password
        // GET: api/user
        [HttpPost]
        public string Login(string userName, string password)
        {
            User Temp = users[users.FindIndex(User => User.name == userName && User.Password == password)];
            if(Temp != null)
            {
                return "Logged in successfully";
            }
            return "Invalid login";
        }
        
        // Adds another user to requesting user's contacts
        // user -   User requesting a contacts
        // id -     Id of user to be added to contacts
        public void AddContact(User user, int id)
        {
            User temp = GetUser(id);
            if(temp != null)
                user.Contacts.Add(temp);
        }

        // Returns a User from a given id if a User exists with that id
        // id -     Id of user to be returned
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
        
        // Returns a User's name from a given id if a User exists with that id
        // id -     Id of user whose name is to be returned
        public string GetUserName(int id)
        {
            User temp = GetUser(id);
            if(temp != null)
                return temp.name;
            return "";
        }
        
        // Delete's a User's account from a given id if a User exists with that id
        // id -     Id of user to be deleted
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            User temp = GetUser(id);
            if(temp != null)
                users.Remove(temp);
        }
    }
}
