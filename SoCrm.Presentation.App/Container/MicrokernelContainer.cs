namespace SoCrm.Presentation.App.Container
{
    using System;

    using Castle.MicroKernel;

    public class MicrokernelContainer : IContainer
    {
        private readonly IKernel _castleKernel;

        public MicrokernelContainer()
            : this(new DefaultKernel())
        {

        }

        public MicrokernelContainer(IKernel castleKernel)
        {
            _castleKernel = castleKernel;
        }

        public T GetA<T>()
        {
            return (T)_castleKernel.Resolve(typeof(T));
        }

        public void RegisterA<T>(Type implementation)
        {
            _castleKernel.AddComponent(typeof(T).FullName, typeof(T), implementation);
        }
    }
}
