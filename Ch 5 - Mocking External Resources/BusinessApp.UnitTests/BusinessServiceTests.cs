using System;

using Ninject;
using NUnit.Framework;

using BusinessApplication;

namespace BusinessApp.UnitTests
{
    [TestFixture]
    public class BusinessServiceTests
    {
        [Test]
        public void ShouldBeAbleToGetBusinessServiceFromNinject()
        {
            BusinessService actual;
            var kernel = new StandardKernel(new CoreModule());
            actual = kernel.Get<BusinessService>();

            Assert.IsNotNull(actual);
        }
    }
}
