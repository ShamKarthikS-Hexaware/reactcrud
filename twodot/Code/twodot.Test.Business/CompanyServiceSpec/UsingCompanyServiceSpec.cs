using NSubstitute;
using twodot.Test.Framework;
using twodot.Business.Services;
using twodot.Data.Interfaces;

namespace twodot.Test.Business.CompanyServiceSpec
{
    public abstract class UsingCompanyServiceSpec : SpecFor<CompanyService>
    {
        protected ICompanyRepository _companyRepository;

        public override void Context()
        {
            _companyRepository = Substitute.For<ICompanyRepository>();
            subject = new CompanyService(_companyRepository);

        }

    }
}
