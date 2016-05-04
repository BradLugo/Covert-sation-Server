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
        private CovertRepository _repository;
        public UserController(CovertRepository repository)
        {
            _repository = repository;
        }

        // Creates a new User
        // userEmail -  User's Email
        // password -   User's password
        // companyId -  User's companyId
        [HttpPost]
        public JsonResult Create([FromBody]User user)
        {
            if (_repository.GetAllUsers().SingleOrDefault(t => t.Email == user.Email) != null)
                return Json(false);
            var temp = new User { Email = user.Email, Password = user.Password, CompanyId = user.CompanyId, IsActive = false };
            _repository.AddUser(temp);
            return Json(true);
        }
        
        //// Checks username and password to log in
        //// userEmail -  User's Email
        //// password -   User's password
        //// GET: api/user
        //[HttpPost]
        //public string Login(string userEmail, string password)
        //{
        //    var temp = _repository.GetAllUsers().FirstOrDefault(user => user.Email == userEmail && user.Password == password);

        //    if(temp != null)
        //    {
        //        temp.IsActive = true;
        //        return "Logged in successfully";
        //    }

        //    return "Invalid login";
        //}
        
        //[HttpGet]
        //public JsonResult Logout(int id)
        //{
        //    //User temp = GetUser(id);
        //    //temp.IsActive = false;
        //    return Json(new { test = "test" });
        //}
        
        //// Adds another user to requesting user's contacts
        //// user -   User requesting a contacts
        //// id -     Id of user to be added to contacts
        //public void AddContact(User user, int id)
        //{
        //    User temp = GetUser(id);
        //    if(temp != null)
        //        user.Contacts.Add(temp);
        //}

        //// Returns a User from a given id if a User exists with that id
        //// id -     Id of user to be returned
        //// GET api/user/5
        //[HttpGet("{id}")]
        //public User GetUser(int id)
        //{
        //    User temp = _repository.GetAllUsers().SingleOrDefault(User => User.Id == id);
        //    if(temp != null)
        //    {
        //        return temp;
        //    }
        //    return null;
        //}
        
        
        //// Returns a User's name from a given id if a User exists with that id
        //// id -     Id of user whose name is to be returned
        //public string GetUserPublicKey(int id)
        //{
        //    User temp = GetUser(id);
        //    if(temp != null)
        //        return temp.PublicKey;
        //    return "";
        //}
        
        //// Returns a True if the User given by the id is active if a User exists with that id
        //// id -     Id of a user whose name is to be returned
        //public bool GetUserActive(int id)
        //{
        //    User temp = GetUser(id);
        //    if(temp != null)
        //        return temp.IsActive;
        //    return false;
        //}
        
        
        //// Delete's a User's account from a given id if a User exists with that id
        //// id -     Id of user to be deleted
        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //    User temp = GetUser(id);
        //    if(temp != null)
        //        _repository.RemoveUser(temp);
        //}
    }
}
