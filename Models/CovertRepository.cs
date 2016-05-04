using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covert_sation_Server.Models
{
    public class CovertRepository
    {
        private CovertContext _context;

        public CovertRepository(CovertContext context)
        {
            _context = context;
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return _context.Users.SingleOrDefault(user => user.Id == id);
        }

        public void RemoveUser(User user)
        {
            _context.Users.Remove(user);
        }

        public IEnumerable<Group> GetAllGroups()
        {
            return _context.Groups.ToList();
        }

        public IEnumerable<Message> GetAllMessages()
        {
            return _context.Messages.ToList();
        }
    }
}
