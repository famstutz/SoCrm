namespace SoCrm.Presentation.Core.Tests.Testables
{
    using Microsoft.Practices.Unity;

    using SoCrm.Presentation.Core.Interfaces;

    public class TestableController : ControllerBase
    {
        public TestableController(IUnityContainer unityContainer, IRegion mainRegion)
            : base(unityContainer, mainRegion)
        {
        }
    }
}
