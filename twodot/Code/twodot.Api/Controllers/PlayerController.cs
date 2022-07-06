using System.Collections.Generic;
using twodot.Business.Interfaces;
using twodot.Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace twodot.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        IPlayerService _PlayerService;
        public PlayerController(IPlayerService PlayerService)
        {
            _PlayerService = PlayerService;
        }

        // GET: api/Player
        [HttpGet]
        public ActionResult<IEnumerable<Player>> Get()
        {
            return Ok(_PlayerService.GetAll());
        }

        [HttpPost]
        public ActionResult<Player> Save(Player Player)
        {
            return Ok(_PlayerService.Save(Player));

        }

        [HttpPut("{id}")]
        public ActionResult<Player> Update([FromRoute] string id, Player Player)
        {
            return Ok(_PlayerService.Update(id, Player));

        }

        [HttpDelete("{id}")]
        public ActionResult<bool> Delete([FromRoute] string id)
        {
            return Ok(_PlayerService.Delete(id));

        }


    }
}
