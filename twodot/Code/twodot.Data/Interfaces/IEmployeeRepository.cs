using twodot.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace twodot.Data.Interfaces
{
    public interface IEmployeeRepository : IGetAll<Employee>, ISave<Employee>, IUpdate<Employee, string>, IDelete<string>
    {
    }
}
