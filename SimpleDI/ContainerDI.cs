using System;
using SimpleDI.Abstract;

namespace SimpleDI
{
    public class ContainerDI
    {
        public IBuilderDi BuilderDi { get; private set; }
        
        public ContainerDI(Func<IBuilderDi, IBuilderDi> build)
        {
            BuilderDi = build(new BuilderDI());
        }
    }   
}