using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRM_ProjectAPI.DTOs
{
    public class ScenarioDTO
    {
        public int ScenarioID { get; set; }
        public String ScenarioName { get; set; }
        public String Description { get; set; }
        public String Location { get; set; }
        public int NumOfScene { get; set; }
        public DateTime StartOnDT { get; set; }
        public DateTime EndOnDT { get; set; }
        public String FileDescriptionPath { get; set; }
    }
}
