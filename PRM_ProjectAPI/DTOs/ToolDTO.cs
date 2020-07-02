using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRM_ProjectAPI.DTOs
{
    public class ToolDTO
    {
        public int ToolID { get; set; }
        public string ToolName { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Amount { get; set; }
        public int Status { get; set; }
    }
}
