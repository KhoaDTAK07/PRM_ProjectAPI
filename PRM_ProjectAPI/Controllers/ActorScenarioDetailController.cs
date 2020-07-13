using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRM_ProjectAPI.DTOs;
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

        [HttpPost]
        public void addActorToScenario([FromBody] ActorScenarioDetailDTO actorScenarioDetailDTO)
        {
            try
            {
                _scenarioDetailRepo.addActorToScenario(actorScenarioDetailDTO);
            }
            catch
            {
                BadRequest();
            }
        }
    }
}