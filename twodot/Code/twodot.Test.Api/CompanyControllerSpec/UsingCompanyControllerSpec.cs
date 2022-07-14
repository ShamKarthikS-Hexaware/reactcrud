using NSubstitute;
using twodot.Test.Framework;
using twodot.Api.Controllers;
using twodot.Business.Interfaces;


namespace twodot.Test.Api.CompanyControllerSpec
{
    public abstract class UsingCompanyControllerSpec : SpecFor<CompanyController>
    {
        protected ICompanyService _companyService;

        public override void Context()
        {
            _companyService = Substitute.For<ICompanyService>();
            subject = new CompanyController(_companyService);

        }

    }
}
