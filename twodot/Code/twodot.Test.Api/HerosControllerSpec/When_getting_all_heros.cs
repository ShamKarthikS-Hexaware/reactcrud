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
    public class When_getting_all_heros : UsingHerosControllerSpec
    {
        private ActionResult<IEnumerable<Heros>> _result;

        private IEnumerable<Heros> _all_heros;
        private Heros _heros;

        public override void Context()
        {
            base.Context();

            _heros = new Heros{
                name = "name"
            };

            _all_heros = new List<Heros> { _heros};
            _herosService.GetAll().Returns(_all_heros);
        }
        public override void Because()
        {
            _result = subject.Get();
        }

        [Test]
        public void Request_is_routed_through_service()
        {
            _herosService.Received(1).GetAll();

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.Result.ShouldBeOfType<OkObjectResult>();

            var resultListObject = (_result.Result as OkObjectResult).Value;

            resultListObject.ShouldBeOfType<List<Heros>>();

            List<Heros> resultList = resultListObject as List<Heros>;

            resultList.Count.ShouldBe(1);

            resultList.ShouldBe(_all_heros);
        }
    }
}
