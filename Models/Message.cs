using System.Collections.Generic;

namespace Covert_sation_Server.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public int Timer { get; set; }

        public ICollection<User> Receivers { get; set; }
    }
}
