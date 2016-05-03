using System.Collections.Generic;

namespace Covert_sation_Server.Models
{
    public class SystemAdmin
    {
        public int UserId { get; set; }

        public virtual ICollection<User> SystemAdmins { get; set; }
    }
}