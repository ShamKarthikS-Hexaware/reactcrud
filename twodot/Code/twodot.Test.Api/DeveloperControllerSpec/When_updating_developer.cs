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
    public class When_updating_developer : UsingDeveloperControllerSpec
    {
        private ActionResult<Developer > _result;
        private Developer _developer;

        public override void Context()
        {
            base.Context();

            _developer = new Developer
            {
                name = "name"
            };

            _developerService.Update(_developer.Id, _developer).Returns(_developer);
            
        }
        public override void Because()
        {
            _result = subject.Update(_developer.Id, _developer);
        }

        [Test]
        public void Request_is_routed_through_service()
        {
            _developerService.Received(1).Update(_developer.Id, _developer);

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.Result.ShouldBeOfType<OkObjectResult>();

            var resultListObject = (_result.Result as OkObjectResult).Value;

            resultListObject.ShouldBeOfType<Developer>();

            var resultList = resultListObject as Developer;

            resultList.ShouldBe(_developer);
        }
    }
}
