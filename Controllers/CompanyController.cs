using EL_KooD_API.Data.Domain;
using EL_KooD_API.Data.Models;
using EL_KooD_API.Infrastructure.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetTopologySuite.Geometries;
using Location = EL_KooD_API.Data.Models.Location;

namespace EL_KooD_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepository _repository;
        public CompanyController(ICompanyRepository repository)
        {
            _repository = repository;
        }
        [HttpPost("Add_Company")]
        public async Task<IActionResult> AddCmpany([FromBody] CompanyModel company)
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
            var NewCompany = new Company
            {                
                Name = company.Name,
                Activity = company.Activity,
                Creation_Date = company.Creation_Date,
                Location = new Point(company.Location.Longitude, company.Location.Latitude)
                { SRID = company.Location.SIRD }
            };
            await _repository.Create(NewCompany);
            CompanyModel Added_Result = new CompanyModel(NewCompany.Id)
            {
                Name = NewCompany.Name,
                Activity = NewCompany.Activity,
                Creation_Date = NewCompany.Creation_Date,
                Location = new Location() { Latitude = NewCompany.Location.X, Longitude = NewCompany.Location.Y }
            };
            return Ok(Added_Result);
        }
        //[HttpGet("GetAllCompanies")]
        //public async Task<IActionResult> getall()
        //{
        //    var res = _repository.GetAllCompanies();
        //    return Ok(res);
        //}
    }
}
