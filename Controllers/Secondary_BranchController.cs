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
    public class Secondary_BranchController : ControllerBase
    {
        private readonly ISecondary_BranchRepository _SecondaryBranch_Repository;
        private readonly ICompanyRepository _Company_Repository;
        public Secondary_BranchController(ISecondary_BranchRepository repository, ICompanyRepository company_Repository)
        {
            _SecondaryBranch_Repository = repository;
            _Company_Repository = company_Repository;
        }
        [HttpPost("Add_Secondary_Branch")]
        public async Task<IActionResult> AddSecondary_Branch([FromBody] Secondary_BranchModel secondary_Branch)
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
            var Company = await _Company_Repository.GetById(secondary_Branch.Company_Id);
            var NewSecondary_Branch = new Secondary_Branch()
            {
                Name = secondary_Branch.Name,
                Address = secondary_Branch.Address,
                Company = Company
            };
            await _SecondaryBranch_Repository.Create(NewSecondary_Branch);
            return Ok();
        }
    }
}
