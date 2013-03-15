namespace SoCrm.Presentation.App.Container
{
    using System;
    using System.Collections;

    public interface IContainer
    {
        T GetA<T>();
        T GetA<T>(IDictionary arguments);
        void RegisterA<T>(Type type);
    }
}
