using twodot.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace twodot.Business.Interfaces
{
    public interface IHerosService
    {      
        IEnumerable<Heros> GetAll();
        Heros Save(Heros classification);
        Heros Update(string id, Heros classification);
        bool Delete(string id);

    }
}
