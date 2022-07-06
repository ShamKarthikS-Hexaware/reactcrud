using System.Collections.Generic;
using twodot.Business.Interfaces;
using twodot.Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace twodot.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        ICompanyService _CompanyService;
        public CompanyController(ICompanyService CompanyService)
        {
            _CompanyService = CompanyService;
        }

        // GET: api/Company
        [HttpGet]
        public ActionResult<IEnumerable<Company>> Get()
        {
            return Ok(_CompanyService.GetAll());
        }

        [HttpPost]
        public ActionResult<Company> Save(Company Company)
        {
            return Ok(_CompanyService.Save(Company));

        }

        [HttpPut("{id}")]
        public ActionResult<Company> Update([FromRoute] string id, Company Company)
        {
            return Ok(_CompanyService.Update(id, Company));

        }

        [HttpDelete("{id}")]
        public ActionResult<bool> Delete([FromRoute] string id)
        {
            return Ok(_CompanyService.Delete(id));

        }


    }
}
