using System;
using System.Collections.Generic;

namespace PRM_ProjectAPI.Models
{
    public partial class User
    {
        public User()
        {
            ActorScenarioDetails = new HashSet<ActorScenarioDetail>();
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Sex { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime Dob { get; set; }
        public int IsAdmin { get; set; }
        public int Status { get; set; }

        public virtual ICollection<ActorScenarioDetail> ActorScenarioDetails { get; set; }
    }
}
