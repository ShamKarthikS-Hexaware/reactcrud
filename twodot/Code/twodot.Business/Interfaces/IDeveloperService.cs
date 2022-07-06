using twodot.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace twodot.Business.Interfaces
{
    public interface IDeveloperService
    {      
        IEnumerable<Developer> GetAll();
        Developer Save(Developer classification);
        Developer Update(string id, Developer classification);
        bool Delete(string id);

    }
}
