using twodot.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace twodot.Data.Interfaces
{
    public interface IDesignerRepository : IGetAll<Designer>, ISave<Designer>, IUpdate<Designer, string>, IDelete<string>
    {
    }
}
