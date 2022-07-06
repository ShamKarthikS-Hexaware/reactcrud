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
    public class When_updating_player : UsingPlayerControllerSpec
    {
        private ActionResult<Player > _result;
        private Player _player;

        public override void Context()
        {
            base.Context();

            _player = new Player
            {
                name = "name"
            };

            _playerService.Update(_player.Id, _player).Returns(_player);
            
        }
        public override void Because()
        {
            _result = subject.Update(_player.Id, _player);
        }

        [Test]
        public void Request_is_routed_through_service()
        {
            _playerService.Received(1).Update(_player.Id, _player);

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.Result.ShouldBeOfType<OkObjectResult>();

            var resultListObject = (_result.Result as OkObjectResult).Value;

            resultListObject.ShouldBeOfType<Player>();

            var resultList = resultListObject as Player;

            resultList.ShouldBe(_player);
        }
    }
}
