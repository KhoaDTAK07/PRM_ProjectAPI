using System;
using System.Collections.Generic;

namespace PRM_ProjectAPI.Models
{
    public partial class Account
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }

        public virtual Actor Actor { get; set; }
    }
}
