using System.Collections.Generic;
using twodot.Business.Interfaces;
using twodot.Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace twodot.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HerosController : ControllerBase
    {
        IHerosService _HerosService;
        public HerosController(IHerosService HerosService)
        {
            _HerosService = HerosService;
        }

        // GET: api/Heros
        [HttpGet]
        public ActionResult<IEnumerable<Heros>> Get()
        {
            return Ok(_HerosService.GetAll());
        }

        [HttpPost]
        public ActionResult<Heros> Save(Heros Heros)
        {
            return Ok(_HerosService.Save(Heros));

        }

        [HttpPut("{id}")]
        public ActionResult<Heros> Update([FromRoute] string id, Heros Heros)
        {
            return Ok(_HerosService.Update(id, Heros));

        }

        [HttpDelete("{id}")]
        public ActionResult<bool> Delete([FromRoute] string id)
        {
            return Ok(_HerosService.Delete(id));

        }


    }
}
