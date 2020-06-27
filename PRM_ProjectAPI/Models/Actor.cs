using System;
using System.Collections.Generic;

namespace PRM_ProjectAPI.Models
{
    public partial class Actor
    {
        public Actor()
        {
            ActorScenarioDetails = new HashSet<ActorScenarioDetail>();
        }

        public string ActorId { get; set; }
        public string ActorName { get; set; }
        public string Sex { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime Dob { get; set; }

        public virtual Account ActorNavigation { get; set; }
        public virtual ICollection<ActorScenarioDetail> ActorScenarioDetails { get; set; }
    }
}
