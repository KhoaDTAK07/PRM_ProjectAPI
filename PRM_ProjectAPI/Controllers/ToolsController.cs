using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PRM_ProjectAPI.DTOs;
using PRM_ProjectAPI.Models;
using PRM_ProjectAPI.Repository;

namespace PRM_ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToolsController : ControllerBase
    {
        private readonly IToolRepository _toolRepo;

        public ToolsController(IToolRepository toolRepo)
        {
            _toolRepo = toolRepo;
        }

        // GET: api/Tools/getall
        [HttpGet("getall")]
        public ActionResult<IEnumerable<Tool>> GetAllToolsAvaliable()
        {
            var list = _toolRepo.GetAllToolAvailable().ToList();
            return Ok(list);
        }

        // GET: api/Tools?toolName={giatri}
        [HttpGet("")]
        public ActionResult<IEnumerable<ToolDTO>> GetToolByName(String toolName = "")
        {
            var tool = _toolRepo.GetToolByName(toolName).ToList();

            if (tool.Count == 0) return NotFound("Khong tim thay tool");
            return Ok(tool);
        }

        // GET: api/Tools?toolID={giatri}
        [HttpGet("{id}")]
        public ActionResult<ToolDTO> GetToolDetailByID(int id)
        {
            var tool = _toolRepo.GetToolDetailByID(id);

            if (tool == null) return NotFound("Khong tim thay tool");
            return Ok(tool);
        }

        // PUT: api/Tools/5
        [HttpPut("{id}")]
        public IActionResult updateTool([FromBody] ToolDTO toolDTO)
        {
            bool isSuccess = _toolRepo.updateTool(toolDTO);

            if (!isSuccess) return NotFound("No no no");

            return Ok("success");
        }

        // POST: api/Tools
        [HttpPost]
        public void createNewTool([FromBody] ToolDTO toolDTO)
        {
            _toolRepo.addNewTool(toolDTO);
        }

        // DELETE: api/Tools/5
        [HttpDelete("")]
        public IActionResult Delete(int toolID)
        {
            bool isSuccess = _toolRepo.deleteTool(toolID);

            if (!isSuccess) return NotFound("No no no");

            return Ok("success");
        }

    }
}
