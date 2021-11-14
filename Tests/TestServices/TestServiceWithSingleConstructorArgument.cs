namespace Tests.TestServices
{
    public class TestServiceWithSingleConstructorArgument
    {
        public readonly TestServiceWithDefaultCtor Service;

        public TestServiceWithSingleConstructorArgument(TestServiceWithDefaultCtor service)
        {
            Service = service;
        }
    }
}