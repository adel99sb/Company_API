using EL_KooD_API.Data.Domain;
using EL_KooD_API.Data.Models;
using EL_KooD_API.Infrastructure.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EL_KooD_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Supply_ProcessController : ControllerBase
    {
        private readonly ISupply_ProcessRepository _supply_ProcessRepository;
        private readonly IManufacturing_ProcessRepository _manufacturing_ProcessRepository;
        private readonly ISecondary_BranchRepository _secondary_BranchRepository;
        public Supply_ProcessController(ISupply_ProcessRepository supply_ProcessRepository, IManufacturing_ProcessRepository manufacturing_ProcessRepository, ISecondary_BranchRepository secondary_BranchRepository)
        {
            _supply_ProcessRepository = supply_ProcessRepository;
            _manufacturing_ProcessRepository = manufacturing_ProcessRepository;
            _secondary_BranchRepository = secondary_BranchRepository;
        }
        [HttpPost("Add_Supply_Process")]
        public async Task<IActionResult> AddSupply_Process([FromBody] Supply_ProcessModel supply_Process)
        {
            if (!ModelState.IsValid)
            {
                string message = "";
                foreach (var M in ModelState.Values)
                {
                    foreach (var m2 in M.Errors)
                    {
                        message += m2.ErrorMessage + "\n";
                    }
                }
                return BadRequest(message);
            }
            var Secondary_Branch = await _secondary_BranchRepository.GetById(supply_Process.Secondary_Branch_Id);
            var Manufacturing_Process = await _manufacturing_ProcessRepository.GetById(supply_Process.Manufacturing_Process_Id);
            var NewSupply_Process = new Supply_Process()
            {
                Quantity = supply_Process.Quantity,
                Creation_Date = supply_Process.Creation_Date,
                Secondary_Branch = Secondary_Branch,
                Manufacturing_Process = Manufacturing_Process
            };
            await _supply_ProcessRepository.Create(NewSupply_Process);
            return Ok();
        }
    }
}
