using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRM_ProjectAPI.DTOs;
using PRM_ProjectAPI.Models;
using PRM_ProjectAPI.Repository;

namespace PRM_ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScenarioController : ControllerBase
    {
        private readonly IScenarioRepository _scenarioRepo;

        public ScenarioController(IScenarioRepository scenarioRepo)
        {
            _scenarioRepo = scenarioRepo;
        }

        // GET: api/Tools/getall
        [HttpGet("getall")]
        public ActionResult<IEnumerable<Scenario>> GetAllScenarioAvaliable()
        {
            var list = _scenarioRepo.GetAllScenarioAvailable().ToList();
            return Ok(list);
        }

        // GET: api/Tools?toolName={giatri}
        [HttpGet("")]
        public ActionResult<IEnumerable<ScenarioDTO>> GetScenarioByName(String scenarioName = "")
        {
            var scenario = _scenarioRepo.GetScenarioByName(scenarioName).ToList();

            if (scenario.Count == 0) return NotFound("Khong tim thay scenario");
            return Ok(scenario);
        }

        // GET: api/Tools?toolID={giatri}
        [HttpGet("{id}")]
        public ActionResult<ScenarioDTO> GetScenarioDetailByID(int id)
        {
            var scenario = _scenarioRepo.GetScenarioDetailByID(id);

            if (scenario == null) return NotFound("Khong tim thay scenario");
            return Ok(scenario);
        }

        // PUT: api/Tools/5
        [HttpPut("{id}")]
        public IActionResult updateScenario([FromBody] ScenarioDTO scenarioDTO)
        {
            bool isSuccess = _scenarioRepo.updateScenario(scenarioDTO);

            if (!isSuccess) return NotFound("No no no");

            return Ok("success");
        }

        // POST: api/Tools
        [HttpPost]
        public void createNewScenario([FromBody] ScenarioDTO scenarioDTO)
        {
            _scenarioRepo.addNewScenario(scenarioDTO);
        }

        // DELETE: api/Tools/5
        [HttpDelete("")]
        public IActionResult Delete(int scenarioID)
        {
            bool isSuccess = _scenarioRepo.deleteScenario(scenarioID);

            if (!isSuccess) return NotFound("No no no");

            return Ok("success");
        }
    }
}