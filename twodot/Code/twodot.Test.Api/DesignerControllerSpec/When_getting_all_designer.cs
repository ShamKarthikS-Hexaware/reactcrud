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
    public class When_getting_all_designer : UsingDesignerControllerSpec
    {
        private ActionResult<IEnumerable<Designer>> _result;

        private IEnumerable<Designer> _all_designer;
        private Designer _designer;

        public override void Context()
        {
            base.Context();

            _designer = new Designer{
                name = "name"
            };

            _all_designer = new List<Designer> { _designer};
            _designerService.GetAll().Returns(_all_designer);
        }
        public override void Because()
        {
            _result = subject.Get();
        }

        [Test]
        public void Request_is_routed_through_service()
        {
            _designerService.Received(1).GetAll();

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.Result.ShouldBeOfType<OkObjectResult>();

            var resultListObject = (_result.Result as OkObjectResult).Value;

            resultListObject.ShouldBeOfType<List<Designer>>();

            List<Designer> resultList = resultListObject as List<Designer>;

            resultList.Count.ShouldBe(1);

            resultList.ShouldBe(_all_designer);
        }
    }
}
