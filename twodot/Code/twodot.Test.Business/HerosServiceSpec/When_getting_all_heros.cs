using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using twodot.Entities.Entities;

namespace twodot.Test.Business.HerosServiceSpec
{
    public class When_getting_all_heros : UsingHerosServiceSpec
    {
        private IEnumerable<Heros> _result;

        private IEnumerable<Heros> _all_heros;
        private Heros _heros;

        public override void Context()
        {
            base.Context();

            _heros = new Heros{
                name = "name"
            };

            _all_heros = new List<Heros> { _heros};
            _herosRepository.GetAll().Returns(_all_heros);
        }
        public override void Because()
        {
            _result = subject.GetAll();
        }

        [Test]
        public void Request_is_routed_through_repository()
        {
            _herosRepository.Received(1).GetAll();

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.ShouldBeOfType<List<Heros>>();

            List<Heros> resultList = _result as List<Heros>;

            resultList.Count.ShouldBe(1);

            resultList.ShouldBe(_all_heros);
        }
    }
}
