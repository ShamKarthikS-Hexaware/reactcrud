using NSubstitute;
using twodot.Test.Framework;
using twodot.Business.Services;
using twodot.Data.Interfaces;

namespace twodot.Test.Business.PlayerServiceSpec
{
    public abstract class UsingPlayerServiceSpec : SpecFor<PlayerService>
    {
        protected IPlayerRepository _playerRepository;

        public override void Context()
        {
            _playerRepository = Substitute.For<IPlayerRepository>();
            subject = new PlayerService(_playerRepository);

        }

    }
}
