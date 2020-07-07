using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRM_ProjectAPI.DTOs
{
    public class UserLoginDetailDTO
    {
        public string Username { get; set; }
        public string Fullname { get; set; }
        public string Image { get; set; }
        public int IsAdmin { get; set; }
    }
}
