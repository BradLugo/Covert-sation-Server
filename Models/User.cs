using System.Collections.Generic;

namespace Covert_sation_Server.Models
{
    public class User
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<User> Contacts { get; set; }
    }
}