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
    public class ToolScenarioDetailController : ControllerBase
    {
        private readonly IToolScenarioDetailRepository _toolScenarioDetailRepo;

        public ToolScenarioDetailController(IToolScenarioDetailRepository toolScenarioDetailRepo)
        {
            _toolScenarioDetailRepo = toolScenarioDetailRepo;
        }

        [HttpGet("getall")]
        public ActionResult<IEnumerable<ToolScenarioDetail>> GetAllAvaliableByScenarioID(int scenarioID)
        {
            var list = _toolScenarioDetailRepo.GetAllAvailableByScenarioID(scenarioID).ToList();
            return Ok(list);
        }

        [HttpPost]
        public async Task<IActionResult> addToolToScenario([FromBody] ToolScenarioDetailDTO toolScenarioDetailDTO)
        {
            try
            {
               if (await _toolScenarioDetailRepo.AddToolToScenario(toolScenarioDetailDTO))
                {
                    return NoContent();
                }
                return BadRequest("Add failed");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}