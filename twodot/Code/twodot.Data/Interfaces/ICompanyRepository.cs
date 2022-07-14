using twodot.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace twodot.Data.Interfaces
{
    public interface ICompanyRepository : IGetAll<Company>, ISave<Company>, IUpdate<Company, string>, IDelete<string>
    {
    }
}
