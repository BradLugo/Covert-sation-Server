using System.Collections.Generic;

namespace Covert_sation_Server.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public User Admin { get; set; }
        public ICollection<User> Members { get; set; }
    }
}