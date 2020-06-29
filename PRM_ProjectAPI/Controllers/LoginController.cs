using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRM_ProjectAPI.DTOs;
using PRM_ProjectAPI.Models;

namespace PRM_ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly PRM_JourneyToTheWestContext _context;

        public LoginController(PRM_JourneyToTheWestContext context)
        {
            _context = context;
        }

        //Post: api/Login
        [HttpPost]
        public ActionResult<UserLoginDTO> GetUser(UserLoginDTO userLoginDTO)
        {
            //ở đây gọi repo login truyền tham số vào
            //var info = _account.CheckLogin(userLoginDTO.Username, userLoginDTO.Password);
            //trả về dữ liệu nếu tìm thấy
            //if (info != null) return Ok(info);
            //không tim thấy trả về ko tìm thấy
            //else return NotFound();
            var accountLogin = _context.Users
                                .Where(acc => acc.Username.Equals(userLoginDTO.Username)
                                && acc.Password.Equals(userLoginDTO.Password))
                                .Select(acc => new AccountDTO
                                {
                                    Username = acc.Username,
                                    IsAdmin = acc.IsAdmin,
                                }).FirstOrDefault();
            return Ok(accountLogin);
        }
    }
}