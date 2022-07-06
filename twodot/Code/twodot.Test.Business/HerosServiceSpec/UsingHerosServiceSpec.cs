using NSubstitute;
using twodot.Test.Framework;
using twodot.Business.Services;
using twodot.Data.Interfaces;

namespace twodot.Test.Business.HerosServiceSpec
{
    public abstract class UsingHerosServiceSpec : SpecFor<HerosService>
    {
        protected IHerosRepository _herosRepository;

        public override void Context()
        {
            _herosRepository = Substitute.For<IHerosRepository>();
            subject = new HerosService(_herosRepository);

        }

    }
}
