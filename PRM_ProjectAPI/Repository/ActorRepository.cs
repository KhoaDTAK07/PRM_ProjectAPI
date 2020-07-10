using PRM_ProjectAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PRM_ProjectAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace PRM_ProjectAPI.Repository
{
    public class ActorRepository : IActorRepository
    {

        private readonly PRM_JourneyToTheWestContext _context;

        public ActorRepository(PRM_JourneyToTheWestContext context)
        {
            _context = context;
        }

        public IEnumerable<ActorDTO> GetAllActorAvailable()
        {
            var ListActor = _context.Users
                                          .Where(actInfo => actInfo.IsAdmin == 0
                                          && actInfo.Status != 0)
                                          .Select(actInfo => new ActorDTO
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

        public IEnumerable<ActorDTO> GetActorByName(string fullName)
        {
            var ListActor = _context.Users
                                          .Where(actInfo => actInfo.IsAdmin == 0
                                          && actInfo.Status != 0
                                          && actInfo.FullName.Contains(fullName))
                                          .Select(actInfo => new ActorDTO
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

        public ActorDTO GetActorByID(string username)
        {
            var actor = _context.Users
                                          .Where(actInfo => actInfo.IsAdmin == 0
                                          && actInfo.Username == username)
                                          .Select(actInfo => new ActorDTO
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
                                          }).FirstOrDefault();
            return actor;
        }
        public void addNewActor(ActorDTO actorDTO)
        {

            User user2add = new User
            {
                Username = actorDTO.Username,
                Password = actorDTO.Password,
                FullName = actorDTO.FullName,
                Sex = actorDTO.Sex,
                Image = actorDTO.Image,
                Description = actorDTO.Description,
                Phone = actorDTO.Phone,
                Email = actorDTO.Email,
                Dob = actorDTO.DOB,
                IsAdmin = actorDTO.IsAdmin,
                Status = actorDTO.Status

            };

            _context.Users.Add(user2add);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                throw;
            }

        }

        public bool updateActor(ActorDTO actorDTO)
        {

            var user = _context.Users.Where(actInfo => actInfo.IsAdmin == 0 && actInfo.Username == actorDTO.Username).FirstOrDefault();

            if (user == null) return false;

            user.FullName = actorDTO.FullName;
            user.Sex = actorDTO.Sex;
            user.Image = actorDTO.Image;
            user.Description = actorDTO.Description;
            user.Phone = actorDTO.Phone;
            user.Email = actorDTO.Email;
            user.Dob = actorDTO.DOB;
            user.IsAdmin = actorDTO.IsAdmin;
            user.Status = actorDTO.Status;

            try
            {
                _context.SaveChanges();
                return true;
            }
            catch (DbUpdateException)
            {
                throw;
            }
            
        }

        public bool deleteActor(string username)
        {

            var user = _context.Users.Where(actInfo => actInfo.IsAdmin == 0 && actInfo.Username == username).FirstOrDefault();

            if (user == null) return false;
            user.Status = 0;

            _context.SaveChanges();
            return true;
        }

    }

    public interface IActorRepository
    {
        IEnumerable<ActorDTO> GetAllActorAvailable();
        ActorDTO GetActorByID(string username);
        IEnumerable<ActorDTO> GetActorByName(string fullName);

        void addNewActor(ActorDTO actorDTO);

        bool updateActor(ActorDTO actorDTO);

        bool deleteActor(string username);

    }
}