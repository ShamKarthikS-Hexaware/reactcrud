using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using Microsoft.AspNetCore.Mvc;
using twodot.Entities.Entities;

namespace twodot.Test.Api.PlayerControllerSpec
{
    public class When_getting_all_player : UsingPlayerControllerSpec
    {
        private ActionResult<IEnumerable<Player>> _result;

        private IEnumerable<Player> _all_player;
        private Player _player;

        public override void Context()
        {
            base.Context();

            _player = new Player{
                name = "name"
            };

            _all_player = new List<Player> { _player};
            _playerService.GetAll().Returns(_all_player);
        }
        public override void Because()
        {
            _result = subject.Get();
        }

        [Test]
        public void Request_is_routed_through_service()
        {
            _playerService.Received(1).GetAll();

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.Result.ShouldBeOfType<OkObjectResult>();

            var resultListObject = (_result.Result as OkObjectResult).Value;

            resultListObject.ShouldBeOfType<List<Player>>();

            List<Player> resultList = resultListObject as List<Player>;

            resultList.Count.ShouldBe(1);

            resultList.ShouldBe(_all_player);
        }
    }
}
