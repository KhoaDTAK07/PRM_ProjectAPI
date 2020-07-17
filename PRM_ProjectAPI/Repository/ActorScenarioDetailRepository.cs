using Microsoft.EntityFrameworkCore;
using PRM_ProjectAPI.DTOs;
using PRM_ProjectAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRM_ProjectAPI.Repository
{
    public class ActorScenarioDetailRepository : IActorScenarioDetailRepository
    {
        private readonly PRM_JourneyToTheWestContext _context;

        public ActorScenarioDetailRepository(PRM_JourneyToTheWestContext context)
        {
            _context = context;
        }

        public void addActorToScenario(ActorScenarioDetailDTO actorScenarioDetailDTO)
        {
            ActorScenarioDetail addActor2Scenario = new ActorScenarioDetail
            {
                ScenarioId = actorScenarioDetailDTO.ScenarioID,
                ActorId = actorScenarioDetailDTO.ActorID,
                CharacterName = actorScenarioDetailDTO.CharacterName,
                CreateBy = actorScenarioDetailDTO.CreateBy,
                Status = 1,
            };

            _context.ActorScenarioDetails.Add(addActor2Scenario);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }

        public bool deleteActorFromScenario(int AsdID)
        {
            var value = _context.ActorScenarioDetails.Where(info => info.AsdId == AsdID).FirstOrDefault();

            if (value == null) return false;
            value.Status = 0;

            _context.SaveChanges();
            return true;
        }

        public IEnumerable<ActorScenarioDetailDTO> GetAllAvailableByScenarioID(int scenarioID)
        {
            var list = _context.ActorScenarioDetails.Where(info => info.Status == 1
                                                           && info.ScenarioId == scenarioID)
                                                    .Select(info => new ActorScenarioDetailDTO
                                                    {
                                                        AsdID = info.AsdId,
                                                        ScenarioID = info.ScenarioId,
                                                        ActorID = info.ActorId,
                                                        CharacterName = info.CharacterName,
                                                        CreateBy = info.CreateBy,
                                                        Status = info.Status,
                                                        FullName = info.Actor.FullName,
                                                        ScenarioName = info.Scenario.ScenarioName,
                                                    });

            return list;
        }

        public IEnumerable<ActorScenarioDetailDTO> GetAllScenarioComingByUsername(string username)
        {
            var list = _context.ActorScenarioDetails.Where(info => info.Status == 1
                                                           && info.Actor.Username == username
                                                           && DateTime.Compare(DateTime.Now, info.Scenario.StartOnDt) < 0)
                                                    .Select(info => new ActorScenarioDetailDTO
                                                    {
                                                        AsdID = info.AsdId,
                                                        ScenarioID = info.ScenarioId,
                                                        ActorID = info.ActorId,
                                                        CharacterName = info.CharacterName,
                                                        CreateBy = info.CreateBy,
                                                        Status = info.Status,
                                                        FullName = info.Actor.FullName,
                                                        ScenarioName = info.Scenario.ScenarioName,
                                                        StartOnDt = info.Scenario.StartOnDt,
                                                        EndOnDt = info.Scenario.EndOnDt,
                                                    });

            return list;
        }

        public IEnumerable<ActorScenarioDetailDTO> GetAllScenarioHistoryByUsername(string username)
        {
            var list = _context.ActorScenarioDetails.Where(info => info.Status == 1
                                                           && info.Actor.Username == username
                                                           && DateTime.Compare(DateTime.Now, info.Scenario.EndOnDt) > 0
                                                           && DateTime.Compare(DateTime.Now, info.Scenario.StartOnDt) > 0)
                                                    .Select(info => new ActorScenarioDetailDTO
                                                    {
                                                        AsdID = info.AsdId,
                                                        ScenarioID = info.ScenarioId,
                                                        ActorID = info.ActorId,
                                                        CharacterName = info.CharacterName,
                                                        CreateBy = info.CreateBy,
                                                        Status = info.Status,
                                                        FullName = info.Actor.FullName,
                                                        ScenarioName = info.Scenario.ScenarioName,
                                                        StartOnDt = info.Scenario.StartOnDt,
                                                        EndOnDt = info.Scenario.EndOnDt,
                                                    });

            return list;
        }

        public IEnumerable<ActorScenarioDetailDTO> GetAllScenarioInProcessByUsername(string username)
        {
            var list = _context.ActorScenarioDetails.Where(info => info.Status == 1
                                                           && info.Actor.Username == username
                                                           && DateTime.Compare(DateTime.Now, info.Scenario.EndOnDt) < 0
                                                           && DateTime.Compare(DateTime.Now, info.Scenario.StartOnDt) > 0)
                                                    .Select(info => new ActorScenarioDetailDTO
                                                    {
                                                        AsdID = info.AsdId,
                                                        ScenarioID = info.ScenarioId,
                                                        ActorID = info.ActorId,
                                                        CharacterName = info.CharacterName,
                                                        CreateBy = info.CreateBy,
                                                        Status = info.Status,
                                                        FullName = info.Actor.FullName,
                                                        ScenarioName = info.Scenario.ScenarioName,
                                                        StartOnDt = info.Scenario.StartOnDt,
                                                        EndOnDt = info.Scenario.EndOnDt,
                                                    });

            return list;
        }

        private async Task<int> checkDateFrom()
        {
            DateTime dateFrom = await _context.Scenarios.Select(date => date.StartOnDt).FirstOrDefaultAsync();
            int check = DateTime.Compare(DateTime.Now, dateFrom);
            return check;
        }
    }

    public interface IActorScenarioDetailRepository
    {
        IEnumerable<ActorScenarioDetailDTO> GetAllAvailableByScenarioID(int scenarioID);

        IEnumerable<ActorScenarioDetailDTO> GetAllScenarioHistoryByUsername(string username);
        IEnumerable<ActorScenarioDetailDTO> GetAllScenarioInProcessByUsername(string username);
        IEnumerable<ActorScenarioDetailDTO> GetAllScenarioComingByUsername(string username);

        void addActorToScenario(ActorScenarioDetailDTO actorScenarioDetailDTO);

        bool deleteActorFromScenario(int AsdID);
    }
}
