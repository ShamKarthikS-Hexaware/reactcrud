using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using twodot.Entities.Entities;

namespace twodot.Test.Business.CompanyServiceSpec
{
    public class When_getting_all_company : UsingCompanyServiceSpec
    {
        private IEnumerable<Company> _result;

        private IEnumerable<Company> _all_company;
        private Company _company;

        public override void Context()
        {
            base.Context();

            _company = new Company{
                name = "name"
            };

            _all_company = new List<Company> { _company};
            _companyRepository.GetAll().Returns(_all_company);
        }
        public override void Because()
        {
            _result = subject.GetAll();
        }

        [Test]
        public void Request_is_routed_through_repository()
        {
            _companyRepository.Received(1).GetAll();

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.ShouldBeOfType<List<Company>>();

            List<Company> resultList = _result as List<Company>;

            resultList.Count.ShouldBe(1);

            resultList.ShouldBe(_all_company);
        }
    }
}
