using twodot.Business.Interfaces;
using twodot.Data.Interfaces;
using twodot.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace twodot.Business.Services
{
    public class CompanyService : ICompanyService
    {
        ICompanyRepository _CompanyRepository;

        public CompanyService(ICompanyRepository CompanyRepository)
        {
           this._CompanyRepository = CompanyRepository;
        }
        public IEnumerable<Company> GetAll()
        {
            return _CompanyRepository.GetAll();
        }

        public Company Save(Company Company)
        {
            _CompanyRepository.Save(Company);
            return Company;
        }

        public Company Update(string id, Company Company)
        {
            return _CompanyRepository.Update(id, Company);
        }

        public bool Delete(string id)
        {
            return _CompanyRepository.Delete(id);
        }

    }
}
