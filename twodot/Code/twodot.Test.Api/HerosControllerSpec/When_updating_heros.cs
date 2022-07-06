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
    public class When_updating_heros : UsingHerosControllerSpec
    {
        private ActionResult<Heros > _result;
        private Heros _heros;

        public override void Context()
        {
            base.Context();

            _heros = new Heros
            {
                name = "name"
            };

            _herosService.Update(_heros.Id, _heros).Returns(_heros);
            
        }
        public override void Because()
        {
            _result = subject.Update(_heros.Id, _heros);
        }

        [Test]
        public void Request_is_routed_through_service()
        {
            _herosService.Received(1).Update(_heros.Id, _heros);

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.Result.ShouldBeOfType<OkObjectResult>();

            var resultListObject = (_result.Result as OkObjectResult).Value;

            resultListObject.ShouldBeOfType<Heros>();

            var resultList = resultListObject as Heros;

            resultList.ShouldBe(_heros);
        }
    }
}
