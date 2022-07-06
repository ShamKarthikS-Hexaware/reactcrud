using System.Collections.Generic;
using twodot.Business.Interfaces;
using twodot.Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace twodot.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DesignerController : ControllerBase
    {
        IDesignerService _DesignerService;
        public DesignerController(IDesignerService DesignerService)
        {
            _DesignerService = DesignerService;
        }

        // GET: api/Designer
        [HttpGet]
        public ActionResult<IEnumerable<Designer>> Get()
        {
            return Ok(_DesignerService.GetAll());
        }

        [HttpPost]
        public ActionResult<Designer> Save(Designer Designer)
        {
            return Ok(_DesignerService.Save(Designer));

        }

        [HttpPut("{id}")]
        public ActionResult<Designer> Update([FromRoute] string id, Designer Designer)
        {
            return Ok(_DesignerService.Update(id, Designer));

        }

        [HttpDelete("{id}")]
        public ActionResult<bool> Delete([FromRoute] string id)
        {
            return Ok(_DesignerService.Delete(id));

        }


    }
}
