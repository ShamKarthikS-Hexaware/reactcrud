using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using twodot.Entities.Entities;


namespace twodot.Test.Business.DesignerServiceSpec
{
    public class When_updating_designer : UsingDesignerServiceSpec
    {
        private Designer _result;
        private Designer _designer;

        public override void Context()
        {
            base.Context();

            _designer = new Designer
            {
                name = "name"
            };

            _designerRepository.Update(_designer.Id, _designer).Returns(_designer);
            
        }
        public override void Because()
        {
            _result = subject.Update(_designer.Id, _designer);
        }

        [Test]
        public void Request_is_routed_through_repository()
        {
            _designerRepository.Received(1).Update(_designer.Id, _designer);

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.ShouldBeOfType<Designer>();

            _result.ShouldBe(_designer);
        }
    }
}
