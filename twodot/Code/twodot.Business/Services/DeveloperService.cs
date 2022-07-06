using twodot.Business.Interfaces;
using twodot.Data.Interfaces;
using twodot.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace twodot.Business.Services
{
    public class DeveloperService : IDeveloperService
    {
        IDeveloperRepository _DeveloperRepository;

        public DeveloperService(IDeveloperRepository DeveloperRepository)
        {
           this._DeveloperRepository = DeveloperRepository;
        }
        public IEnumerable<Developer> GetAll()
        {
            return _DeveloperRepository.GetAll();
        }

        public Developer Save(Developer Developer)
        {
            _DeveloperRepository.Save(Developer);
            return Developer;
        }

        public Developer Update(string id, Developer Developer)
        {
            return _DeveloperRepository.Update(id, Developer);
        }

        public bool Delete(string id)
        {
            return _DeveloperRepository.Delete(id);
        }

    }
}
