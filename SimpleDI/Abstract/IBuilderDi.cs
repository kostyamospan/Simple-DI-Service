using System;

namespace SimpleDI.Abstract
{
    public interface IBuilderDi
    {
        T GetRegisteredService<T>() where T: class;
        IBuilderDi RegisterService<T>() where T : class;
        bool IsRegistered<T>();
        bool IsRegistered(Type type);
    }
}