using PRM_ProjectAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PRM_ProjectAPI.Models;

namespace PRM_ProjectAPI.Repository {
    public class UserRepository : IUserRepository {

        private readonly PRM_JourneyToTheWestContext _context;

        public UserRepository(PRM_JourneyToTheWestContext context)
        {
            _context = context;
        }

        //IEnum dùng khi List Không thì trả về dto
        public AccountDTO CheckLogin(string username, string password)
        {
            var accountLogin = _context.Users
                                .Where(acc => acc.Username.Equals(username)
                                && acc.Password.Equals(password))
                                .Select(acc => new AccountDTO
                                {
                                    Username = acc.Username,
                                    IsAdmin = acc.IsAdmin,
                                }).FirstOrDefault();
            return accountLogin;
        }

        public IEnumerable<AccountDTO> GetActorList(int isAdmin, int status) {
            var ListActor = _context.Users
                                          .Where(actInfo => actInfo.IsAdmin == isAdmin 
                                          && actInfo.Status == status)
                                          .Select( actInfo => new AccountDTO
                                          {
                                             FullName = actInfo.FullName,
                                             Sex = actInfo.Sex,
                                             Image = actInfo.Image,
                                             Description = actInfo.Description,
                                             Phone = actInfo.Phone,
                                             Email = actInfo.Email,
                                             DOB = actInfo.Dob,
                                          });
            return ListActor;
        }


    }

    public interface IUserRepository
        {
            AccountDTO CheckLogin(string username, string password);
            IEnumerable<AccountDTO> GetActorList(int IsAdmin, int Status);
        }
}