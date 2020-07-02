using System;
using System.Collections.Generic;

namespace PRM_ProjectAPI.Models
{
    public partial class Scenario
    {
        public Scenario()
        {
            ActorScenarioDetails = new HashSet<ActorScenarioDetail>();
            ToolScenarioDetails = new HashSet<ToolScenarioDetail>();
        }

        public int ScenarioId { get; set; }
        public string ScenarioName { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int NumOfScene { get; set; }
        public DateTime StartOnDt { get; set; }
        public DateTime EndOnDt { get; set; }
        public string FileDescriptionPath { get; set; }
        public int Status { get; set; }

        public virtual ICollection<ActorScenarioDetail> ActorScenarioDetails { get; set; }
        public virtual ICollection<ToolScenarioDetail> ToolScenarioDetails { get; set; }
    }
}
