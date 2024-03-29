using System.Collections.Generic;

namespace Covert_sation_Server.Models
{
    public class User
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public string PublicKey { get; set; }
        
        public ICollection<User> Contacts { get; set; }
        public ICollection<UserMessage> Messages { get; set; }
    }
}