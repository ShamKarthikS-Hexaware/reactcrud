using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using twodot.Entities.Entities;


namespace twodot.Test.Business.EmployeeServiceSpec
{
    public class When_updating_employee : UsingEmployeeServiceSpec
    {
        private Employee _result;
        private Employee _employee;

        public override void Context()
        {
            base.Context();

            _employee = new Employee
            {
                name = "name"
            };

            _employeeRepository.Update(_employee.Id, _employee).Returns(_employee);
            
        }
        public override void Because()
        {
            _result = subject.Update(_employee.Id, _employee);
        }

        [Test]
        public void Request_is_routed_through_repository()
        {
            _employeeRepository.Received(1).Update(_employee.Id, _employee);

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.ShouldBeOfType<Employee>();

            _result.ShouldBe(_employee);
        }
    }
}
