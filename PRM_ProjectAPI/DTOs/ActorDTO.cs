using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRM_ProjectAPI.DTOs
{
    public class ActorDTO
    {
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Sex { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime DOB { get; set; }
        public int IsAdmin { get; set; }
        public int Status { get; set; }
    }
}
