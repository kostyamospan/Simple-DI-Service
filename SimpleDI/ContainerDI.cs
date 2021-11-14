using System;
using SimpleDI.Abstract;

namespace SimpleDI
{
    public class ContainerDI
    {
        public IBuilderDi BuilderDi { get; private set; } = new BuilderDI();
        
        public ContainerDI(Action<IBuilderDi> build)
        {
            build(BuilderDi);
        }
    }   
}