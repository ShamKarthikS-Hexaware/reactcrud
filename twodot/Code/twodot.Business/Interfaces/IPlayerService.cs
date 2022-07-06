using twodot.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace twodot.Business.Interfaces
{
    public interface IPlayerService
    {      
        IEnumerable<Player> GetAll();
        Player Save(Player classification);
        Player Update(string id, Player classification);
        bool Delete(string id);

    }
}
