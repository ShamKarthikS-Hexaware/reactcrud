using NSubstitute;
using twodot.Test.Framework;
using twodot.Api.Controllers;
using twodot.Business.Interfaces;


namespace twodot.Test.Api.HerosControllerSpec
{
    public abstract class UsingHerosControllerSpec : SpecFor<HerosController>
    {
        protected IHerosService _herosService;

        public override void Context()
        {
            _herosService = Substitute.For<IHerosService>();
            subject = new HerosController(_herosService);

        }

    }
}
