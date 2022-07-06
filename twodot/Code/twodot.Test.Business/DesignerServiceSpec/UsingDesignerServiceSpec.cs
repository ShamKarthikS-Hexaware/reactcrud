using NSubstitute;
using twodot.Test.Framework;
using twodot.Business.Services;
using twodot.Data.Interfaces;

namespace twodot.Test.Business.DesignerServiceSpec
{
    public abstract class UsingDesignerServiceSpec : SpecFor<DesignerService>
    {
        protected IDesignerRepository _designerRepository;

        public override void Context()
        {
            _designerRepository = Substitute.For<IDesignerRepository>();
            subject = new DesignerService(_designerRepository);

        }

    }
}
