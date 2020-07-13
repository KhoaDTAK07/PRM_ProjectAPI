using System;
using System.Collections.Generic;

namespace PRM_ProjectAPI.Models
{
    public partial class ActorScenarioDetail
    {
        public int AsdId { get; set; }
        public int ScenarioId { get; set; }
        public string ActorId { get; set; }
        public string CharacterName { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateOnDt { get; set; }
        public int Status { get; set; }

        public virtual User Actor { get; set; }
        public virtual Scenario Scenario { get; set; }
    }
}
