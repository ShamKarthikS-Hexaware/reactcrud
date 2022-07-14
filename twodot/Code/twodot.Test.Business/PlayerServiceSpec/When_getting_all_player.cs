using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using twodot.Entities.Entities;

namespace twodot.Test.Business.PlayerServiceSpec
{
    public class When_getting_all_player : UsingPlayerServiceSpec
    {
        private IEnumerable<Player> _result;

        private IEnumerable<Player> _all_player;
        private Player _player;

        public override void Context()
        {
            base.Context();

            _player = new Player{
                name = "name"
            };

            _all_player = new List<Player> { _player};
            _playerRepository.GetAll().Returns(_all_player);
        }
        public override void Because()
        {
            _result = subject.GetAll();
        }

        [Test]
        public void Request_is_routed_through_repository()
        {
            _playerRepository.Received(1).GetAll();

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.ShouldBeOfType<List<Player>>();

            List<Player> resultList = _result as List<Player>;

            resultList.Count.ShouldBe(1);

            resultList.ShouldBe(_all_player);
        }
    }
}
