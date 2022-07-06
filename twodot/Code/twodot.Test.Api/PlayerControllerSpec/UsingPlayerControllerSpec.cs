using NSubstitute;
using twodot.Test.Framework;
using twodot.Api.Controllers;
using twodot.Business.Interfaces;


namespace twodot.Test.Api.PlayerControllerSpec
{
    public abstract class UsingPlayerControllerSpec : SpecFor<PlayerController>
    {
        protected IPlayerService _playerService;

        public override void Context()
        {
            _playerService = Substitute.For<IPlayerService>();
            subject = new PlayerController(_playerService);

        }

    }
}
