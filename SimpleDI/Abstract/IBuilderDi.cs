using System;

namespace SimpleDI.Abstract
{
    public interface IBuilderDi
    {
        T GetRegisteredService<T>() where T: new();
        IBuilderDi RegisterService<T>() where T : new();
    }
}