using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using twodot.Entities.Entities;

namespace twodot.Test.Business.DesignerServiceSpec
{
    public class When_getting_all_designer : UsingDesignerServiceSpec
    {
        private IEnumerable<Designer> _result;

        private IEnumerable<Designer> _all_designer;
        private Designer _designer;

        public override void Context()
        {
            base.Context();

            _designer = new Designer{
                name = "name"
            };

            _all_designer = new List<Designer> { _designer};
            _designerRepository.GetAll().Returns(_all_designer);
        }
        public override void Because()
        {
            _result = subject.GetAll();
        }

        [Test]
        public void Request_is_routed_through_repository()
        {
            _designerRepository.Received(1).GetAll();

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.ShouldBeOfType<List<Designer>>();

            List<Designer> resultList = _result as List<Designer>;

            resultList.Count.ShouldBe(1);

            resultList.ShouldBe(_all_designer);
        }
    }
}
