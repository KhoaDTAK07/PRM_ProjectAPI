using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRM_ProjectAPI.DTOs
{
    public class ToolScenarioDetailDTO
    {
        public int TsdId { get; set; }
        public int ScenarioId { get; set; }
        public String ScenarioName { get; set; }
        public int ToolId { get; set; }
        public String ToolName { get; set; }
        public int Amount { get; set; }
        public DateTime? CreateOnDt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateOnDt { get; set; }
        public int Status { get; set; }
    }
}
