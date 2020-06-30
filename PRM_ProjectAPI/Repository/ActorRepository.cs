using PRM_ProjectAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PRM_ProjectAPI.Models;

namespace PRM_ProjectAPI.Repository {
    public class ActorRepository : IActorRepository
    {

        private readonly PRM_JourneyToTheWestContext _context;

        public ActorRepository(PRM_JourneyToTheWestContext context)
        {
            _context = context;
        }

        public IEnumerable<ActorDTO> GetActorList(int isAdmin, int status) {
            var ListActor = _context.Users
                                          .Where(actInfo => actInfo.IsAdmin == isAdmin 
                                          && actInfo.Status == status)
                                          .Select( actInfo => new ActorDTO
                                          {
                                             Username = actInfo.Username,
                                             FullName = actInfo.FullName,
                                             Sex = actInfo.Sex,
                                             Image = actInfo.Image,
                                             Description = actInfo.Description,
                                             Phone = actInfo.Phone,
                                             Email = actInfo.Email,
                                             DOB = actInfo.Dob,
                                             Status = actInfo.Status
                                          });
            return ListActor;
        }


    }

    public interface IActorRepository
    {          
            IEnumerable<ActorDTO> GetActorList(int IsAdmin, int Status);
        }
}