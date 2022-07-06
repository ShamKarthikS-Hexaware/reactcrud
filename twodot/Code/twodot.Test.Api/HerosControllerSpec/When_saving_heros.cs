using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using Microsoft.AspNetCore.Mvc;
using twodot.Entities.Entities;

namespace twodot.Test.Api.HerosControllerSpec
{
    public class When_saving_heros : UsingHerosControllerSpec
    {
        private ActionResult<Heros> _result;

        private Heros _heros;

        public override void Context()
        {
            base.Context();

            _heros = new Heros
            {
                name = "name"
            };

            _herosService.Save(_heros).Returns(_heros);
        }
        public override void Because()
        {
            _result = subject.Save(_heros);
        }

        [Test]
        public void Request_is_routed_through_service()
        {
            _herosService.Received(1).Save(_heros);

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.Result.ShouldBeOfType<OkObjectResult>();

            var resultListObject = (_result.Result as OkObjectResult).Value;

            resultListObject.ShouldBeOfType<Heros>();

            var resultList = (Heros)resultListObject;

            resultList.ShouldBe(_heros);
        }
    }
}
