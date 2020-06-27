using System;
using System.Collections.Generic;

namespace PRM_ProjectAPI.Models
{
    public partial class ActorScenarioDetail
    {
        public int ScenarioId { get; set; }
        public string ActorId { get; set; }
        public string CharacterName { get; set; }
        public string FileDescriptionPath { get; set; }

        public virtual Actor Actor { get; set; }
        public virtual Scenario Scenario { get; set; }
    }
}
