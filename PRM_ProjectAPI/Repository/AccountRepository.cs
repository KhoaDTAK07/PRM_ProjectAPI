using PRM_ProjectAPI.DTOs;
using PRM_ProjectAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRM_ProjectAPI.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly PRM_JourneyToTheWestContext _context;
        public AccountRepository(PRM_JourneyToTheWestContext context)
        {
            _context = context;
        }
        //IEnum dùng khi List Không thì trả về dto
        public AccountDTO CheckLogin(string username, string password)
        {
            var accountLogin = _context.Accounts
                                .Where(acc => acc.Username.Equals(username)
                                && acc.Password.Equals(password))
                                .Select(acc => new AccountDTO
                                {
                                    Username = acc.Username,
                                    Role = acc.Role,
                                }).FirstOrDefault();
            return accountLogin;
        }
    }

    public interface IAccountRepository
    {
        AccountDTO CheckLogin(string username, string password);
    }
}
