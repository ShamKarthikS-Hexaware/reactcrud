using twodot.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace twodot.Data.Interfaces
{
    public interface IDeveloperRepository : IGetAll<Developer>, ISave<Developer>, IUpdate<Developer, string>, IDelete<string>
    {
    }
}
