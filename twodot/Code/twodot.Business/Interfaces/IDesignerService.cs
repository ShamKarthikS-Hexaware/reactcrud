using twodot.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace twodot.Business.Interfaces
{
    public interface IDesignerService
    {      
        IEnumerable<Designer> GetAll();
        Designer Save(Designer classification);
        Designer Update(string id, Designer classification);
        bool Delete(string id);

    }
}
