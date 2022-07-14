using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using Microsoft.AspNetCore.Mvc;
using twodot.Entities.Entities;

namespace twodot.Test.Api.EmployeeControllerSpec
{
    public class When_updating_employee : UsingEmployeeControllerSpec
    {
        private ActionResult<Employee > _result;
        private Employee _employee;

        public override void Context()
        {
            base.Context();

            _employee = new Employee
            {
                name = "name"
            };

            _employeeService.Update(_employee.Id, _employee).Returns(_employee);
            
        }
        public override void Because()
        {
            _result = subject.Update(_employee.Id, _employee);
        }

        [Test]
        public void Request_is_routed_through_service()
        {
            _employeeService.Received(1).Update(_employee.Id, _employee);

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.Result.ShouldBeOfType<OkObjectResult>();

            var resultListObject = (_result.Result as OkObjectResult).Value;

            resultListObject.ShouldBeOfType<Employee>();

            var resultList = resultListObject as Employee;

            resultList.ShouldBe(_employee);
        }
    }
}
