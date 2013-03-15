namespace SoCrm.Presentation.App.Container
{
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
    }
}
