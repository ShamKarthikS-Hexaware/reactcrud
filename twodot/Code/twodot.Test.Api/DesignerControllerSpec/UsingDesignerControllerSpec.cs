using NSubstitute;
using twodot.Test.Framework;
using twodot.Api.Controllers;
using twodot.Business.Interfaces;


namespace twodot.Test.Api.DesignerControllerSpec
{
    public abstract class UsingDesignerControllerSpec : SpecFor<DesignerController>
    {
        protected IDesignerService _designerService;

        public override void Context()
        {
            _designerService = Substitute.For<IDesignerService>();
            subject = new DesignerController(_designerService);

        }

    }
}
