using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRM_ProjectAPI.DTOs;
using PRM_ProjectAPI.Models;
using PRM_ProjectAPI.Repository;
using Microsoft.EntityFrameworkCore;

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

        //GET: api/Actors
        [HttpGet]
        public ActionResult<IEnumerable<ActorDTO>> GetListActor(int isAdmin, int status)
        {
            var list =  _userRepo.GetActorList(isAdmin, status).ToList();
            if (list.Count == 0) return NotFound();
            else return Ok(list);
        }
    }
}