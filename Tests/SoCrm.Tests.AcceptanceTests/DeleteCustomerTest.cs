﻿namespace SoCrm.Tests.AcceptanceTests
{
    using Microsoft.VisualStudio.TestTools.UITesting;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [CodedUITest]
    public class DeleteCustomerTest : CodedUITestBase
    {
        [TestMethod]
        public override void Execute()
        {
            this.UIMap.OpenAuthentication();
            this.UIMap.EnterCredentials();
            this.UIMap.LogOn();

            this.UIMap.OpenPersonList();
            //this.UIMap.DeletePerson();
        }
    }
}
