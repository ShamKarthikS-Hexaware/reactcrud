using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using twodot.Entities.Entities;

namespace twodot.Test.Business.CompanyServiceSpec
{
    public class When_saving_company : UsingCompanyServiceSpec
    {
        private Company _result;

        private Company _company;

        public override void Context()
        {
            base.Context();

            _company = new Company
            {
                name = "name"
            };

            _companyRepository.Save(_company).Returns(true);
        }
        public override void Because()
        {
            _result = subject.Save(_company);
        }

        [Test]
        public void Request_is_routed_through_repository()
        {
            _companyRepository.Received(1).Save(_company);

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.ShouldBeOfType<Company>();

            _result.ShouldBe(_company);
        }
    }
}
