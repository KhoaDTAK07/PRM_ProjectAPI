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
    public class ActorScenarioDetailController : ControllerBase
    {
        private readonly IActorScenarioDetailRepository _scenarioDetailRepo;

        public ActorScenarioDetailController(IActorScenarioDetailRepository scenarioDetailRepo)
        {
            _scenarioDetailRepo = scenarioDetailRepo;
        }

        [HttpGet("getall")]
        public ActionResult<IEnumerable<ActorScenarioDetail>> GetAllAvaliableByScenarioID(int scenarioID)
        {
            var list = _scenarioDetailRepo.GetAllAvailableByScenarioID(scenarioID).ToList();
            return Ok(list);
        }

        [HttpGet("getHistory")]
        public ActionResult<IEnumerable<ActorScenarioDetail>> GetHistoryByUsername(string username)
        {
            var list = _scenarioDetailRepo.GetAllScenarioHistoryByUsername(username).ToList();
            return Ok(list);
        }

        [HttpGet("getInProcess")]
        public ActionResult<IEnumerable<ActorScenarioDetail>> GetInProcessByUsername(string username)
        {
            var list = _scenarioDetailRepo.GetAllScenarioInProcessByUsername(username).ToList();
            return Ok(list);
        }

        [HttpGet("getComing")]
        public ActionResult<IEnumerable<ActorScenarioDetail>> GetComingByUsername(string username)
        {
            var list = _scenarioDetailRepo.GetAllScenarioComingByUsername(username).ToList();
            return Ok(list);
        }

        [HttpPost]
        public IActionResult addActorToScenario([FromBody] ActorScenarioDetailDTO actorScenarioDetailDTO)
        {
            try
            {
                _scenarioDetailRepo.addActorToScenario(actorScenarioDetailDTO);
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // DELETE: api/Tools/5
        [HttpDelete("")]
        public IActionResult Delete(int AsdID)
        {
            bool isSuccess = _scenarioDetailRepo.deleteActorFromScenario(AsdID);

            if (!isSuccess) return NotFound("No no no");

            return Ok("success");
        }
    }
}