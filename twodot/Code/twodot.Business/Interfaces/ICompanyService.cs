using twodot.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace twodot.Business.Interfaces
{
    public interface ICompanyService
    {      
        IEnumerable<Company> GetAll();
        Company Save(Company classification);
        Company Update(string id, Company classification);
        bool Delete(string id);

    }
}
