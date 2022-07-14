using NSubstitute;
using twodot.Test.Framework;
using twodot.Business.Services;
using twodot.Data.Interfaces;

namespace twodot.Test.Business.DeveloperServiceSpec
{
    public abstract class UsingDeveloperServiceSpec : SpecFor<DeveloperService>
    {
        protected IDeveloperRepository _developerRepository;

        public override void Context()
        {
            _developerRepository = Substitute.For<IDeveloperRepository>();
            subject = new DeveloperService(_developerRepository);

        }

    }
}
