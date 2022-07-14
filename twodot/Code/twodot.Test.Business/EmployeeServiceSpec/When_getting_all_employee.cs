using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using twodot.Entities.Entities;

namespace twodot.Test.Business.EmployeeServiceSpec
{
    public class When_getting_all_employee : UsingEmployeeServiceSpec
    {
        private IEnumerable<Employee> _result;

        private IEnumerable<Employee> _all_employee;
        private Employee _employee;

        public override void Context()
        {
            base.Context();

            _employee = new Employee{
                name = "name"
            };

            _all_employee = new List<Employee> { _employee};
            _employeeRepository.GetAll().Returns(_all_employee);
        }
        public override void Because()
        {
            _result = subject.GetAll();
        }

        [Test]
        public void Request_is_routed_through_repository()
        {
            _employeeRepository.Received(1).GetAll();

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.ShouldBeOfType<List<Employee>>();

            List<Employee> resultList = _result as List<Employee>;

            resultList.Count.ShouldBe(1);

            resultList.ShouldBe(_all_employee);
        }
    }
}
