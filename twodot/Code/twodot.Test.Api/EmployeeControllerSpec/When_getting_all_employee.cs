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
    public class When_getting_all_employee : UsingEmployeeControllerSpec
    {
        private ActionResult<IEnumerable<Employee>> _result;

        private IEnumerable<Employee> _all_employee;
        private Employee _employee;

        public override void Context()
        {
            base.Context();

            _employee = new Employee{
                name = "name"
            };

            _all_employee = new List<Employee> { _employee};
            _employeeService.GetAll().Returns(_all_employee);
        }
        public override void Because()
        {
            _result = subject.Get();
        }

        [Test]
        public void Request_is_routed_through_service()
        {
            _employeeService.Received(1).GetAll();

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.Result.ShouldBeOfType<OkObjectResult>();

            var resultListObject = (_result.Result as OkObjectResult).Value;

            resultListObject.ShouldBeOfType<List<Employee>>();

            List<Employee> resultList = resultListObject as List<Employee>;

            resultList.Count.ShouldBe(1);

            resultList.ShouldBe(_all_employee);
        }
    }
}
