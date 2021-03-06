﻿using System;
using System.Collections.Generic;

namespace PRM_ProjectAPI.Models
{
    public partial class ToolScenarioDetail
    {
        public int TsdId { get; set; }
        public int ScenarioId { get; set; }
        public int ToolId { get; set; }
        public int Amount { get; set; }
        public DateTime? CreateOnDt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateOnDt { get; set; }
        public int Status { get; set; }

        public virtual Scenario Scenario { get; set; }
        public virtual Tool Tool { get; set; }
    }
}
