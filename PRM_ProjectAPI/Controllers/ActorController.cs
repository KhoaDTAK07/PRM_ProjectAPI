using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using PRM_ProjectAPI.DTOs;
using PRM_ProjectAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PRM_ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly IActorRepository _userRepo;

        public ActorController(IActorRepository userRepo)
        {
            _userRepo = userRepo;
        }

        //GET: api/actor/getall
        [HttpGet("getall")]
        public ActionResult<IEnumerable<ActorDTO>> GetAllActorAvailable()
        {
            var list = _userRepo.GetAllActorAvailable().ToList();
            return Ok(list);
        }

        // GET: api/actor?fullName={giatri}
        [HttpGet("")]
        public ActionResult<IEnumerable<ActorDTO>> GetActorListByName(String fullname = "")
        {
            var actor = _userRepo.GetActorByName(fullname).ToList();

            if (actor.Count == 0) return NotFound("Khong tim thay user");
            return Ok(actor);
        }

        //GET: api/actor?username={giatri}
        [HttpGet("{username}")]
        public ActionResult<IEnumerable<ActorDTO>> GetActorByID(String username = "")
        {
            var user = _userRepo.GetActorByID(username);
            if (user == null) return NotFound("Khong tim thay user");
            return Ok(user);
        }

        [HttpPost]
        public IActionResult createNewActor([FromBody] ActorDTO actorDTO)
        {
            try
            {
                _userRepo.addNewActor(actorDTO);
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult updateUser([FromBody] ActorDTO actorDTO)
        {
            bool isSuccess = _userRepo.updateActor(actorDTO);

            if (!isSuccess) return NotFound("No no no");

            return Ok("success");
        }

        // DELETE api/values/5
        [HttpDelete("")]
        public IActionResult Delete(string username)
        {
            bool isSuccess = _userRepo.deleteActor(username);

            if (!isSuccess) return NotFound("No no no");

            return Ok("success");
        }


    }
}