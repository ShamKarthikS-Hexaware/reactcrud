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
    public class When_saving_company : UsingCompanyControllerSpec
    {
        private ActionResult<Company> _result;

        private Company _company;

        public override void Context()
        {
            base.Context();

            _company = new Company
            {
                name = "name"
            };

            _companyService.Save(_company).Returns(_company);
        }
        public override void Because()
        {
            _result = subject.Save(_company);
        }

        [Test]
        public void Request_is_routed_through_service()
        {
            _companyService.Received(1).Save(_company);

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.Result.ShouldBeOfType<OkObjectResult>();

            var resultListObject = (_result.Result as OkObjectResult).Value;

            resultListObject.ShouldBeOfType<Company>();

            var resultList = (Company)resultListObject;

            resultList.ShouldBe(_company);
        }
    }
}
