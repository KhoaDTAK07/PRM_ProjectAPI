using PRM_ProjectAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRM_ProjectAPI.Repository
{
    public class ScenarioRepository
    {
    }

    public interface IScenarioRepository
    {
        IEnumerable<ScenarioDTO> GetAllScenarioAvailable();
        IEnumerable<ScenarioDTO> GetScenarioByName(string scenarioName);

        ScenarioDTO GetScenarioDetailByID(int scenarioID);

        void addNewScenario(ScenarioDTO scenarioDTO);

        bool updateScenario(ScenarioDTO scenarioDTO);

        bool deleteScenario(string toolName);
    }
}
