using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using twodot.Entities.Entities;

namespace twodot.Test.Business.DeveloperServiceSpec
{
    public class When_getting_all_developer : UsingDeveloperServiceSpec
    {
        private IEnumerable<Developer> _result;

        private IEnumerable<Developer> _all_developer;
        private Developer _developer;

        public override void Context()
        {
            base.Context();

            _developer = new Developer{
                name = "name"
            };

            _all_developer = new List<Developer> { _developer};
            _developerRepository.GetAll().Returns(_all_developer);
        }
        public override void Because()
        {
            _result = subject.GetAll();
        }

        [Test]
        public void Request_is_routed_through_repository()
        {
            _developerRepository.Received(1).GetAll();

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.ShouldBeOfType<List<Developer>>();

            List<Developer> resultList = _result as List<Developer>;

            resultList.Count.ShouldBe(1);

            resultList.ShouldBe(_all_developer);
        }
    }
}
