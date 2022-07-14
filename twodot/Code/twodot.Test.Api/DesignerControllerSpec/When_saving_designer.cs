using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using Microsoft.AspNetCore.Mvc;
using twodot.Entities.Entities;

namespace twodot.Test.Api.DesignerControllerSpec
{
    public class When_saving_designer : UsingDesignerControllerSpec
    {
        private ActionResult<Designer> _result;

        private Designer _designer;

        public override void Context()
        {
            base.Context();

            _designer = new Designer
            {
                name = "name"
            };

            _designerService.Save(_designer).Returns(_designer);
        }
        public override void Because()
        {
            _result = subject.Save(_designer);
        }

        [Test]
        public void Request_is_routed_through_service()
        {
            _designerService.Received(1).Save(_designer);

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.Result.ShouldBeOfType<OkObjectResult>();

            var resultListObject = (_result.Result as OkObjectResult).Value;

            resultListObject.ShouldBeOfType<Designer>();

            var resultList = (Designer)resultListObject;

            resultList.ShouldBe(_designer);
        }
    }
}
