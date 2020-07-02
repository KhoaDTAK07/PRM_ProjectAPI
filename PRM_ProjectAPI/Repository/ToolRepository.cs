using PRM_ProjectAPI.DTOs;
using PRM_ProjectAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRM_ProjectAPI.Repository
{
    public class ToolRepository : IToolRepository
    {
        private readonly PRM_JourneyToTheWestContext _context;

        public ToolRepository(PRM_JourneyToTheWestContext context)
        {
            _context = context;
        }

        public void addNewTool(ToolDTO toolDTO)
        {
            Tool tool2add = new Tool
            {
                ToolId = toolDTO.ToolID,
                ToolName = toolDTO.ToolName,
                Description = toolDTO.Description,
                Image = toolDTO.Image,
                Amount = toolDTO.Amount,
                Status = 1,
            };

            _context.Tools.Add(tool2add);
            _context.SaveChanges();
        }

        public bool deleteTool(string toolName)
        {
            var tool = _context.Tools.Where(toolInfo => toolInfo.ToolName == toolName).FirstOrDefault();

            if (tool == null) return false;
            tool.Status = 0;

            _context.SaveChanges();
            return true;
        }

        public IEnumerable<ToolDTO> GetAllToolAvailable()
        {
            var listTool = _context.Tools
                                         .Where(toolInfo => toolInfo.Status == 1)
                                         .Select(toolInfo => new ToolDTO
                                         {
                                             ToolID = toolInfo.ToolId,
                                             ToolName = toolInfo.ToolName,
                                             Description = toolInfo.Description,
                                             Image = toolInfo.Image,
                                             Amount = toolInfo.Amount,
                                             Status = toolInfo.Status,
                                         });
            return listTool;
        }

        public IEnumerable<ToolDTO> GetToolByName(string toolName)
        {
            var listTool = _context.Tools
                                         .Where(toolInfo => toolInfo.Status == 1 && toolInfo.ToolName.Contains(toolName))
                                         .Select(toolInfo => new ToolDTO
                                         {
                                             ToolID = toolInfo.ToolId,
                                             ToolName = toolInfo.ToolName,
                                             Description = toolInfo.Description,
                                             Image = toolInfo.Image,
                                             Amount = toolInfo.Amount,
                                             Status = toolInfo.Status,
                                         });
            return listTool;
        }

        public ToolDTO GetToolDetailByID(int toolID)
        {
            var tool = _context.Tools
                                         .Where(toolInfo => toolInfo.Status == 1 && toolInfo.ToolId == toolID)
                                         .Select(toolInfo => new ToolDTO
                                         {
                                             ToolID = toolInfo.ToolId,
                                             ToolName = toolInfo.ToolName,
                                             Description = toolInfo.Description,
                                             Image = toolInfo.Image,
                                             Amount = toolInfo.Amount,
                                             Status = toolInfo.Status,
                                         }).FirstOrDefault();
            return tool;
        }

        public bool updateTool(ToolDTO toolDTO)
        {
            var tool = _context.Tools.Where(toolInfo => toolInfo.Status == 1 && toolInfo.ToolName == toolDTO.ToolName).FirstOrDefault();

            if (tool == null) return false;

            tool.ToolName = toolDTO.ToolName;
            tool.Description = toolDTO.Description;
            tool.Image = toolDTO.Image;
            tool.Amount = toolDTO.Amount;
            tool.Status = toolDTO.Status;

            _context.SaveChanges();
            return true;
        }
    }

    public interface IToolRepository
    {
        IEnumerable<ToolDTO> GetAllToolAvailable();
        IEnumerable<ToolDTO> GetToolByName(string toolName);

        ToolDTO GetToolDetailByID(int toolID);

        void addNewTool(ToolDTO toolDTO);

        bool updateTool(ToolDTO toolDTO);

        bool deleteTool(string toolName);
    }

}
