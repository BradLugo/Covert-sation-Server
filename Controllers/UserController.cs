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
        // userEmail -  User's Email
        // password -   User's password
        // companyId -  User's companyId
        public void Create(string userEmail, string password, int companyId)
        {
            if(users.Single(User => User.Email == userEmail) != null)
                return;
            User temp = new User{Email = userEmail, Password = password, CompanyId = companyId, IsActive = false};
            users.Add(temp);
        }
        
        // Checks username and password to log in
        // userEmail -  User's Email
        // password -   User's password
        // GET: api/user
        [HttpPost]
        public string Login(string userEmail, string password)
        {
            User temp = users[users.FindIndex(User => User.Email == userEmail && User.Password == password)];
            if(temp != null)
            {
                temp.IsActive = true;
                return "Logged in successfully";
            }
            return "Invalid login";
        }
        
        public void Logout(int id)
        {
            User temp = GetUser(id);
            temp.IsActive = false;
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
        public string GetUserPublicKey(int id)
        {
            User temp = GetUser(id);
            if(temp != null)
                return temp.PublicKey;
            return "";
        }
        
        // Returns a True if the User given by the id is active if a User exists with that id
        // id -     Id of a user whose name is to be returned
        public bool GetUserActive(int id)
        {
            User temp = GetUser(id);
            if(temp != null)
                return temp.IsActive;
            return false;
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
