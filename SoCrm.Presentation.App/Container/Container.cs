namespace SoCrm.Presentation.App.Container
{
    using System.Collections;

    public static class Container
    {
        private static IContainer container;

        public static void InitializeContainerWith(IContainer containerImplementation)
        {
            container = containerImplementation;
        }

        public static T GetA<T>()
        {
            return container.GetA<T>();
        }

        public static T GetA<T>(IDictionary arguments)
        {
            return container.GetA<T>(arguments);
        }
    }
}
