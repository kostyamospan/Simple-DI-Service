namespace Tests.TestServices
{
    internal  class TestServiceWithSingleConstructorArgument
    {
        public readonly TestServiceWithDefaultCtor Service;

        public TestServiceWithSingleConstructorArgument(TestServiceWithDefaultCtor service)
        {
            Service = service;
        }
    }
}