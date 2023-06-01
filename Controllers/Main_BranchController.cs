using EL_KooD_API.Data.Domain;
using EL_KooD_API.Data.Models;
using EL_KooD_API.Infrastructure.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetTopologySuite.Geometries;

namespace EL_KooD_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Main_BranchController : ControllerBase
    {
        private readonly IMain_BranchRepository _MainBranch_Repository;
        private readonly ICompanyRepository _Company_Repository;
        public Main_BranchController(IMain_BranchRepository repository, ICompanyRepository company_Repository)
        {
            _MainBranch_Repository = repository;
            _Company_Repository = company_Repository;
        }
        [HttpPost("Add_Main_Branch")]
        public async Task<IActionResult> AddMain_Branch([FromBody] Main_BranchModel main_Branch)
        {
            if (!ModelState.IsValid)
            {
                string message = "";
                foreach (var M in ModelState.Values)
                {
                    foreach (var E in M.Errors)
                    {
                        message += E.ErrorMessage + "\n";
                    }
                }
                return BadRequest(message);
            }
            var Company = await _Company_Repository.GetById(main_Branch.Company_Id);
            var NewMain_Branch = new Main_Branch()
            {
                Name = main_Branch.Name,
                Address = main_Branch.Address,
                Company = Company
            };
            await _MainBranch_Repository.Create(NewMain_Branch);
            return Ok();
        }
    }
}
