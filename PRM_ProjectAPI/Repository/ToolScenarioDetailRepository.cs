using Microsoft.EntityFrameworkCore;
using PRM_ProjectAPI.DTOs;
using PRM_ProjectAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRM_ProjectAPI.Repository
{
    public class ToolScenarioDetailRepository : IToolScenarioDetailRepository
    {
        private readonly PRM_JourneyToTheWestContext _context;

        public ToolScenarioDetailRepository(PRM_JourneyToTheWestContext context)
        {
            _context = context;
        }

        public async Task<bool> AddToolToScenario(ToolScenarioDetailDTO toolScenarioDetailDTO)
        {
            bool check = await checkQuantity(toolScenarioDetailDTO.Amount, toolScenarioDetailDTO.ToolId);
            if (check == false)
            {
                return false;
            }
            else
            {
                ToolScenarioDetail toolDetail = new ToolScenarioDetail
                {
                    ScenarioId = toolScenarioDetailDTO.ScenarioId,
                    ToolId = toolScenarioDetailDTO.ToolId,
                    Amount = toolScenarioDetailDTO.Amount,
                    CreateOnDt = toolScenarioDetailDTO.CreateOnDt,
                    Status = 1,
                };

                _context.ToolScenarioDetails.Add(toolDetail);
                try
                {
                    _context.SaveChanges();
                    return true;
                }
                catch (DbUpdateException)
                {
                    throw;
                }
            }
        }

        public IEnumerable<ToolScenarioDetailDTO> GetAllAvailableByScenarioID(int scenarioID)
        {
            var list = _context.ToolScenarioDetails.Where(info => info.Status == 1
                                                           && info.ScenarioId == scenarioID)
                                                    .Select(info => new ToolScenarioDetailDTO
                                                    {
                                                        TsdId = info.TsdId,
                                                        ScenarioId = info.ScenarioId,
                                                        ToolId = info.ToolId,
                                                        Amount = info.Amount,
                                                        Status = info.Status,
                                                        ToolName = info.Tool.ToolName,
                                                        ScenarioName = info.Scenario.ScenarioName,
                                                    });

            return list;
        }


        private async Task<bool> checkQuantity(int quantity, int toolID)
        {
            int checkQuantity = await _context.Tools.Where(tool => tool.ToolId == toolID)
                                                    .Select(tool => tool.Amount)
                                                    .FirstOrDefaultAsync();
            if (quantity < checkQuantity) return true;
            else return false;
        }
    }

    public interface IToolScenarioDetailRepository
    {
        Task<bool> AddToolToScenario(ToolScenarioDetailDTO toolScenarioDetailDTO);
        IEnumerable<ToolScenarioDetailDTO> GetAllAvailableByScenarioID(int scenarioID);
    }
}
