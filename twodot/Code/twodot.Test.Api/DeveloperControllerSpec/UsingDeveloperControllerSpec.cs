using NSubstitute;
using twodot.Test.Framework;
using twodot.Api.Controllers;
using twodot.Business.Interfaces;


namespace twodot.Test.Api.DeveloperControllerSpec
{
    public abstract class UsingDeveloperControllerSpec : SpecFor<DeveloperController>
    {
        protected IDeveloperService _developerService;

        public override void Context()
        {
            _developerService = Substitute.For<IDeveloperService>();
            subject = new DeveloperController(_developerService);

        }

    }
}
