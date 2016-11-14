using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Moq;
using Ninject;
using NUnit.Framework;

using BusinessApplication;


namespace BusinessApp.UnitTests
{
    [TestFixture]
    public class PersonServiceTests
    {
        [Test]
        public void ShouldBeAbleToCallPersonServiceAndGetPerson()
        {
            // This is not truly a unit test because it breaks the boundaries between PersonService and PersonRepository.
            var expected = new Person { Id = 1, FirstName = "John", LastName = "Doe" };
            var kernel = new StandardKernel(new CoreModule());
            var personService = kernel.Get<PersonService>();
            var actual = personService.GetPerson(expected.Id);

            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.FirstName, actual.FirstName);
            Assert.AreEqual(expected.LastName, actual.LastName);
        }

        [Test]
        public void ShouldBeAbleToCallPersonServiceAndGetPersonWithMock()
        {
            // This is a proper unit test
            var expected = new Person { Id = 1, FirstName = "John", LastName = "Doe" };
            var personRepositoryMock = new Mock<IPersonRepository>();
            personRepositoryMock
                .Setup(pr => pr.GetPerson(1))
                .Returns(new Person { Id = 1, FirstName = "Bob", LastName = "Smith" });
            var personService = new PersonService(personRepositoryMock.Object);
            var actual = personService.GetPerson(expected.Id);

            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.FirstName, actual.FirstName);
            Assert.AreEqual(expected.LastName, actual.LastName);
        }
    }
}
