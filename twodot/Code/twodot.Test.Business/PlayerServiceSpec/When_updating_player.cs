using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using twodot.Entities.Entities;


namespace twodot.Test.Business.PlayerServiceSpec
{
    public class When_updating_player : UsingPlayerServiceSpec
    {
        private Player _result;
        private Player _player;

        public override void Context()
        {
            base.Context();

            _player = new Player
            {
                name = "name"
            };

            _playerRepository.Update(_player.Id, _player).Returns(_player);
            
        }
        public override void Because()
        {
            _result = subject.Update(_player.Id, _player);
        }

        [Test]
        public void Request_is_routed_through_repository()
        {
            _playerRepository.Received(1).Update(_player.Id, _player);

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.ShouldBeOfType<Player>();

            _result.ShouldBe(_player);
        }
    }
}
