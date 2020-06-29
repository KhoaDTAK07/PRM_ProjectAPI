using System;
using System.Collections.Generic;

namespace PRM_ProjectAPI.Models
{
    public partial class Tool
    {
        public Tool()
        {
            ToolScenarioDetails = new HashSet<ToolScenarioDetail>();
        }

        public int ToolId { get; set; }
        public string ToolName { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Amount { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<ToolScenarioDetail> ToolScenarioDetails { get; set; }
    }
}
