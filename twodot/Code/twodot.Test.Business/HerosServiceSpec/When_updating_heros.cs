using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using twodot.Entities.Entities;


namespace twodot.Test.Business.HerosServiceSpec
{
    public class When_updating_heros : UsingHerosServiceSpec
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

            _herosRepository.Update(_heros.Id, _heros).Returns(_heros);
            
        }
        public override void Because()
        {
            _result = subject.Update(_heros.Id, _heros);
        }

        [Test]
        public void Request_is_routed_through_repository()
        {
            _herosRepository.Received(1).Update(_heros.Id, _heros);

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.ShouldBeOfType<Heros>();

            _result.ShouldBe(_heros);
        }
    }
}
