using twodot.Business.Interfaces;
using twodot.Data.Interfaces;
using twodot.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace twodot.Business.Services
{
    public class DesignerService : IDesignerService
    {
        IDesignerRepository _DesignerRepository;

        public DesignerService(IDesignerRepository DesignerRepository)
        {
           this._DesignerRepository = DesignerRepository;
        }
        public IEnumerable<Designer> GetAll()
        {
            return _DesignerRepository.GetAll();
        }

        public Designer Save(Designer Designer)
        {
            _DesignerRepository.Save(Designer);
            return Designer;
        }

        public Designer Update(string id, Designer Designer)
        {
            return _DesignerRepository.Update(id, Designer);
        }

        public bool Delete(string id)
        {
            return _DesignerRepository.Delete(id);
        }

    }
}
