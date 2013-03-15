namespace SoCrm.Presentation.App.Container
{
    using System;

    public interface IContainer
    {
        T GetA<T>();
        void RegisterA<T>(Type type);
    }
}
