using twodot.Business.Interfaces;
using twodot.Data.Interfaces;
using twodot.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace twodot.Business.Services
{
    public class PlayerService : IPlayerService
    {
        IPlayerRepository _PlayerRepository;

        public PlayerService(IPlayerRepository PlayerRepository)
        {
           this._PlayerRepository = PlayerRepository;
        }
        public IEnumerable<Player> GetAll()
        {
            return _PlayerRepository.GetAll();
        }

        public Player Save(Player Player)
        {
            _PlayerRepository.Save(Player);
            return Player;
        }

        public Player Update(string id, Player Player)
        {
            return _PlayerRepository.Update(id, Player);
        }

        public bool Delete(string id)
        {
            return _PlayerRepository.Delete(id);
        }

    }
}
