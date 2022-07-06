using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using Microsoft.AspNetCore.Mvc;
using twodot.Entities.Entities;

namespace twodot.Test.Api.DeveloperControllerSpec
{
    public class When_getting_all_developer : UsingDeveloperControllerSpec
    {
        private ActionResult<IEnumerable<Developer>> _result;

        private IEnumerable<Developer> _all_developer;
        private Developer _developer;

        public override void Context()
        {
            base.Context();

            _developer = new Developer{
                name = "name"
            };

            _all_developer = new List<Developer> { _developer};
            _developerService.GetAll().Returns(_all_developer);
        }
        public override void Because()
        {
            _result = subject.Get();
        }

        [Test]
        public void Request_is_routed_through_service()
        {
            _developerService.Received(1).GetAll();

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.Result.ShouldBeOfType<OkObjectResult>();

            var resultListObject = (_result.Result as OkObjectResult).Value;

            resultListObject.ShouldBeOfType<List<Developer>>();

            List<Developer> resultList = resultListObject as List<Developer>;

            resultList.Count.ShouldBe(1);

            resultList.ShouldBe(_all_developer);
        }
    }
}
