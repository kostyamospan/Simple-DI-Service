using SimpleDI.Abstract;

namespace SimpleDI
{
    public class BuilderDI : IBuilderDi
    {
        public T GetRegisteredService<T>() where T : new()
        {
            throw new System.NotImplementedException();
        }

        public IBuilderDi RegisterService<T>() where T : new()
        {
            throw new System.NotImplementedException();
        }
    }
}