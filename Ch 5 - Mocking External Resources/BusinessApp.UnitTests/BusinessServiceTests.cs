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
            // Note: If referencing multiple assemblies, each assembly should have a 'CoreModule', 
            // and the kernal can be initialized as follows:
            //  var kernel = new StandardKernel(new ModuleA(),
            //                                  new ModuleB(),
            //                                  new ModuleC());

            actual = kernel.Get<BusinessService>();

            Assert.IsNotNull(actual);
        }
    }
}
