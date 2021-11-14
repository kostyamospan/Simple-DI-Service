using System;
using SimpleDI;
using SimpleDI.Exceptions;
using Tests.TestServices;
using Xunit;

namespace Tests
{
    public class UnitTest1
    {
        [Fact]
        public void RegisterSimpleDependency()
        {
            var diContainer = new ContainerDI(
                di => { di.RegisterService<TestServiceWithDefaultCtor>(); });

            var service = diContainer.BuilderDi.GetRegisteredService<TestServiceWithDefaultCtor>();

            Assert.NotNull(service);
        }

        [Fact]
        public void RegisterDependencyThatAlreadyExists()
        {
            Assert.Throws<DuplicatedServicesException>(() =>
            {
                var diContainer = new ContainerDI(
                    di =>
                    {
                        di.RegisterService<TestServiceWithDefaultCtor>();
                        di.RegisterService<TestServiceWithDefaultCtor>();
                    });
            });
        }
        
        [Fact]
        public void RegisterDependenciesWithConstructorParameters()
        {
            var diContainer = new ContainerDI(
                di =>
                {
                    di.RegisterService<TestServiceWithDefaultCtor>();
                    di.RegisterService<TestServiceWithSingleConstructorArgument>();
                });

            var service = diContainer.BuilderDi.GetRegisteredService<TestServiceWithSingleConstructorArgument>();

            Assert.NotNull(service?.Service);            
        }
    }
}