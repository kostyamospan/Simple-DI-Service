namespace Tests.TestServices
{
    internal class TestServiceWithCircularDependency
    {
        public TestServiceWithCircularDependency(TestServiceWithCircularDependency service)
        {
                
        }
    }
}