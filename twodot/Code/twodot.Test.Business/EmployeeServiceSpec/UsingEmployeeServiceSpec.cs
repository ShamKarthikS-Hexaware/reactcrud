using NSubstitute;
using twodot.Test.Framework;
using twodot.Business.Services;
using twodot.Data.Interfaces;

namespace twodot.Test.Business.EmployeeServiceSpec
{
    public abstract class UsingEmployeeServiceSpec : SpecFor<EmployeeService>
    {
        protected IEmployeeRepository _employeeRepository;

        public override void Context()
        {
            _employeeRepository = Substitute.For<IEmployeeRepository>();
            subject = new EmployeeService(_employeeRepository);

        }

    }
}
