using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using twodot.Entities.Entities;

namespace twodot.Test.Business.DeveloperServiceSpec
{
    public class When_saving_developer : UsingDeveloperServiceSpec
    {
        private Developer _result;

        private Developer _developer;

        public override void Context()
        {
            base.Context();

            _developer = new Developer
            {
                name = "name"
            };

            _developerRepository.Save(_developer).Returns(true);
        }
        public override void Because()
        {
            _result = subject.Save(_developer);
        }

        [Test]
        public void Request_is_routed_through_repository()
        {
            _developerRepository.Received(1).Save(_developer);

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.ShouldBeOfType<Developer>();

            _result.ShouldBe(_developer);
        }
    }
}
