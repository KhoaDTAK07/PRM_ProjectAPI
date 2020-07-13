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
    }

    public interface IActorScenarioDetailRepository
    {
        void addActorToScenario(ActorScenarioDetailDTO actorScenarioDetailDTO);

        bool deleteActorFromScenario(int AsdID);
    }
}
