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

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
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
