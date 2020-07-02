using PRM_ProjectAPI.DTOs;
using PRM_ProjectAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRM_ProjectAPI.Repository
{
    public class ScenarioRepository : IScenarioRepository
    {
        private readonly PRM_JourneyToTheWestContext _context;

        public ScenarioRepository(PRM_JourneyToTheWestContext context)
        {
            _context = context;
        }

        public void addNewScenario(ScenarioDTO scenarioDTO)
        {
            Scenario scenario2add = new Scenario
            {
                ScenarioId = scenarioDTO.ScenarioID,
                ScenarioName = scenarioDTO.ScenarioName,
                Description = scenarioDTO.Description,
                Location = scenarioDTO.Location,
                NumOfScene = scenarioDTO.NumOfScene,
                StartOnDt = scenarioDTO.StartOnDT,
                EndOnDt = scenarioDTO.EndOnDT,
                FileDescriptionPath = scenarioDTO.FileDescriptionPath,
                Status = 1
            };

            _context.Scenarios.Add(scenario2add);
            _context.SaveChanges();
        }

        public bool deleteScenario(int scenarioID)
        {
            var scenario = _context.Scenarios.Where(scenInfo => scenInfo.ScenarioId == scenarioID).FirstOrDefault();

            if (scenario == null) return false;
            scenario.Status = 0;

            _context.SaveChanges();
            return true;
        }

        public IEnumerable<ScenarioDTO> GetAllScenarioAvailable()
        {
            var listScenario = _context.Scenarios
                                         .Where(scenInfo => scenInfo.Status == 1)
                                         .Select(scenInfo => new ScenarioDTO
                                         {
                                             ScenarioID = scenInfo.ScenarioId,
                                             ScenarioName = scenInfo.ScenarioName,
                                             Description = scenInfo.Description,
                                             Location = scenInfo.Location,
                                             NumOfScene = scenInfo.NumOfScene,
                                             StartOnDT = scenInfo.StartOnDt,
                                             EndOnDT = scenInfo.EndOnDt,
                                             FileDescriptionPath = scenInfo.FileDescriptionPath,
                                             Status = scenInfo.Status,
                                         });
            return listScenario;
        }

        public IEnumerable<ScenarioDTO> GetScenarioByName(string scenarioName)
        {
            throw new NotImplementedException();
        }

        public ScenarioDTO GetScenarioDetailByID(int scenarioID)
        {
            throw new NotImplementedException();
        }

        public bool updateScenario(ScenarioDTO scenarioDTO)
        {
            throw new NotImplementedException();
        }
    }

    public interface IScenarioRepository
    {
        IEnumerable<ScenarioDTO> GetAllScenarioAvailable();
        IEnumerable<ScenarioDTO> GetScenarioByName(string scenarioName);

        ScenarioDTO GetScenarioDetailByID(int scenarioID);

        void addNewScenario(ScenarioDTO scenarioDTO);

        bool updateScenario(ScenarioDTO scenarioDTO);

        bool deleteScenario(int scenarioID);
    }
}
