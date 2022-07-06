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
    public class When_saving_player : UsingPlayerControllerSpec
    {
        private ActionResult<Player> _result;

        private Player _player;

        public override void Context()
        {
            base.Context();

            _player = new Player
            {
                name = "name"
            };

            _playerService.Save(_player).Returns(_player);
        }
        public override void Because()
        {
            _result = subject.Save(_player);
        }

        [Test]
        public void Request_is_routed_through_service()
        {
            _playerService.Received(1).Save(_player);

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.Result.ShouldBeOfType<OkObjectResult>();

            var resultListObject = (_result.Result as OkObjectResult).Value;

            resultListObject.ShouldBeOfType<Player>();

            var resultList = (Player)resultListObject;

            resultList.ShouldBe(_player);
        }
    }
}
