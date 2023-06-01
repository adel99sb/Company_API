using EL_KooD_API.Data.Domain;
using EL_KooD_API.Data.Models;
using EL_KooD_API.Infrastructure.Contracts;
using EL_KooD_API.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EL_KooD_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Manufacturing_ProcessController : ControllerBase
    {
        private readonly IManufacturing_ProcessRepository _manufacturing_ProcessRepository;
        private readonly IMain_BranchRepository _main_BranchRepository;
        private readonly IProductRepository _ProductRepository;
        public Manufacturing_ProcessController(IManufacturing_ProcessRepository manufacturing_ProcessRepository, IMain_BranchRepository main_BranchRepository, IProductRepository productRepository)
        {
            _manufacturing_ProcessRepository = manufacturing_ProcessRepository;
            _main_BranchRepository = main_BranchRepository;
            _ProductRepository = productRepository;
        }
        [HttpPost("Add_Manufacturing_Process")]
        public async Task<IActionResult> AddManufacturing_Process([FromBody] Manufacturing_ProcessModel manufacturing_Process)
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
            var Main_Branch = await _main_BranchRepository.GetById(manufacturing_Process.Main_Branch_Id);
            var Product = await _ProductRepository.GetById(manufacturing_Process.Product_Id);
            var NewManufacturing_Process = new Manufacturing_Process()
            {
                Quantity = manufacturing_Process.Quantity,
                Creation_Date = manufacturing_Process.Creation_Date,
                Main_Branch = Main_Branch,
                Product = Product
            };
            await _manufacturing_ProcessRepository.Create(NewManufacturing_Process);
            return Ok();
        }
        [HttpGet("Get_Manufacturing_Report_With_Date")]
        public async Task<IActionResult> GetManufacturing_Report_WithDate([FromQuery] Manufacturing_ReportModel manufacturing_ReportModel)
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
            var Result = await _manufacturing_ProcessRepository.GetManufacturing_Report_WithDate(manufacturing_ReportModel);
            return Ok(Result);
        }
    }
}
