using PRM_ProjectAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PRM_ProjectAPI.Models;

namespace PRM_ProjectAPI.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly PRM_JourneyToTheWestContext _context;

        public LoginRepository(PRM_JourneyToTheWestContext context)
        {
            _context = context;
        }

        //IEnum dùng khi List Không thì trả về dto
        public UserLoginDetailDTO CheckLogin(string username, string password)
        {
            var accountLogin = _context.Users
                                .Where(acc => acc.Username.Equals(username)
                                && acc.Password.Equals(password))
                                .Select(acc => new UserLoginDetailDTO
                                {
                                    Username = acc.Username,
                                    Fullname = acc.FullName,
                                    Image = acc.Image,
                                    IsAdmin = acc.IsAdmin,
                                }).FirstOrDefault();
            return accountLogin;
        }
    }

    public interface ILoginRepository
    {
        UserLoginDetailDTO CheckLogin(string username, string password);
    }
}
