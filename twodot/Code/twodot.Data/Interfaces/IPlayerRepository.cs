using twodot.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace twodot.Data.Interfaces
{
    public interface IPlayerRepository : IGetAll<Player>, ISave<Player>, IUpdate<Player, string>, IDelete<string>
    {
    }
}
