using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using twodot.Entities.Entities;

namespace twodot.Test.Business.HerosServiceSpec
{
    public class When_saving_heros : UsingHerosServiceSpec
    {
        private Heros _result;

        private Heros _heros;

        public override void Context()
        {
            base.Context();

            _heros = new Heros
            {
                name = "name"
            };

            _herosRepository.Save(_heros).Returns(true);
        }
        public override void Because()
        {
            _result = subject.Save(_heros);
        }

        [Test]
        public void Request_is_routed_through_repository()
        {
            _herosRepository.Received(1).Save(_heros);

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.ShouldBeOfType<Heros>();

            _result.ShouldBe(_heros);
        }
    }
}
