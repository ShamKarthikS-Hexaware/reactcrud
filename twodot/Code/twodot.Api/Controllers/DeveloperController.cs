using System.Collections.Generic;
using twodot.Business.Interfaces;
using twodot.Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace twodot.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DeveloperController : ControllerBase
    {
        IDeveloperService _DeveloperService;
        public DeveloperController(IDeveloperService DeveloperService)
        {
            _DeveloperService = DeveloperService;
        }

        // GET: api/Developer
        [HttpGet]
        public ActionResult<IEnumerable<Developer>> Get()
        {
            return Ok(_DeveloperService.GetAll());
        }

        [HttpPost]
        public ActionResult<Developer> Save(Developer Developer)
        {
            return Ok(_DeveloperService.Save(Developer));

        }

        [HttpPut("{id}")]
        public ActionResult<Developer> Update([FromRoute] string id, Developer Developer)
        {
            return Ok(_DeveloperService.Update(id, Developer));

        }

        [HttpDelete("{id}")]
        public ActionResult<bool> Delete([FromRoute] string id)
        {
            return Ok(_DeveloperService.Delete(id));

        }


    }
}
