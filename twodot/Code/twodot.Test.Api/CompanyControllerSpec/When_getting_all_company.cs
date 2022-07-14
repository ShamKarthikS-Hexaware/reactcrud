using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using Microsoft.AspNetCore.Mvc;
using twodot.Entities.Entities;

namespace twodot.Test.Api.CompanyControllerSpec
{
    public class When_getting_all_company : UsingCompanyControllerSpec
    {
        private ActionResult<IEnumerable<Company>> _result;

        private IEnumerable<Company> _all_company;
        private Company _company;

        public override void Context()
        {
            base.Context();

            _company = new Company{
                name = "name"
            };

            _all_company = new List<Company> { _company};
            _companyService.GetAll().Returns(_all_company);
        }
        public override void Because()
        {
            _result = subject.Get();
        }

        [Test]
        public void Request_is_routed_through_service()
        {
            _companyService.Received(1).GetAll();

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.Result.ShouldBeOfType<OkObjectResult>();

            var resultListObject = (_result.Result as OkObjectResult).Value;

            resultListObject.ShouldBeOfType<List<Company>>();

            List<Company> resultList = resultListObject as List<Company>;

            resultList.Count.ShouldBe(1);

            resultList.ShouldBe(_all_company);
        }
    }
}
