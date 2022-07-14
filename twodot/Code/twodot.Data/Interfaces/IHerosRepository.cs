using twodot.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace twodot.Data.Interfaces
{
    public interface IHerosRepository : IGetAll<Heros>, ISave<Heros>, IUpdate<Heros, string>, IDelete<string>
    {
    }
}
