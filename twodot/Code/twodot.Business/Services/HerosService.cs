using twodot.Business.Interfaces;
using twodot.Data.Interfaces;
using twodot.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace twodot.Business.Services
{
    public class HerosService : IHerosService
    {
        IHerosRepository _HerosRepository;

        public HerosService(IHerosRepository HerosRepository)
        {
           this._HerosRepository = HerosRepository;
        }
        public IEnumerable<Heros> GetAll()
        {
            return _HerosRepository.GetAll();
        }

        public Heros Save(Heros Heros)
        {
            _HerosRepository.Save(Heros);
            return Heros;
        }

        public Heros Update(string id, Heros Heros)
        {
            return _HerosRepository.Update(id, Heros);
        }

        public bool Delete(string id)
        {
            return _HerosRepository.Delete(id);
        }

    }
}
