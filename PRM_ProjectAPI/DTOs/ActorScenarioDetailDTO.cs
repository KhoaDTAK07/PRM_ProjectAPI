using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRM_ProjectAPI.DTOs
{
    public class ActorScenarioDetailDTO
    {
        public int ScenarioID { get; set; }
        public string ActorID { get; set; }
        public string CharacterName { get; set; }
        public string CreateBy { get; set; }
        public int Status { get; set; }
    }
}
