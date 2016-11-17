using System;

using Moq;
using NBehave.Spec.NUnit;
using NHibernate;
using NUnit.Framework;

using OSIM.Core.Entities;
using OSIM.Core.Persistence;

namespace OSIM.UnitTests.OSIM.Core
{
    // Note: Deviating from one file per class for the following reasons:
    // 1. A few large files runs in VS much faster than many small files, which is a consideration for when the project has many tests
    // 2. More in line with BDD protocols, where the tests are more logically grouped together in a way that makes more sense to non-programmers
    // 3. For 1 & 2, this lumps tests into groups with logical seams.

    /// <summary>
    /// First class written after setting up base specification class.
    /// </summary>
    public class when_working_with_the_item_type_repository : Specification
    {
        protected IItemTypeRepository _itemTypeRepository;
        protected Mock<ISessionFactory> _sessionFactory;
        protected Mock<ISession> _session;

        protected override void Establish_context()
        {
            base.Establish_context();

            _sessionFactory = new Mock<ISessionFactory>();
            _session = new Mock<ISession>();

            //  The mock that will stand in for 'sessionFactory' will return the mock created for 'session' when the 'OpenSession' method on the 'sessionFactory' is called.
            _sessionFactory.Setup(sf => sf.OpenSession()).Returns(_session.Object);

            _itemTypeRepository = new ItemTypeRepository(_sessionFactory.Object);
        }
    }

    /// <summary>
    /// Second class written after setting up base specification class.
    /// </summary>
    public class and_saving_a_valid_item_type : when_working_with_the_item_type_repository
    {
        private int _result;
        // Moved to base class: private IItemTypeRepository _itemTypeRepository;
        protected int _itemTypeId;
        protected ItemType _testItemType;

        protected override void Establish_context()
        {
            base.Establish_context();

            var randomNumberGenerator = new Random();
            _itemTypeId = randomNumberGenerator.Next(32000);
            // Moved to base class:  var sessionFactory = new Mock<ISessionFactory>();
            // Moved to base class: var session = new Mock<ISession>();

            // Set up the return value for the mock 'session'.
            _session.Setup(s => s.Save(_testItemType)).Returns(_itemTypeId);

            //  The mock that will stand in for 'sessionFactory' will return the mock created for 'session' when the 'OpenSession' method on the 'sessionFactory' is called.
            // Moved to base class: sessionFactory.Setup(sf => sf.OpenSession()).Returns(session.Object);
        }



        protected override void Because_of()
        {
            _result = _itemTypeRepository.Save(_testItemType);
        }


        /// <summary>
        /// First method written.
        /// </summary>
        [Test]
        public void then_a_valid_item_type_id_should_be_returned()
        {
            _result.ShouldEqual(_itemTypeId);
        }

    }

    /// <summary>
    /// Third class written.
    /// </summary>
    public class and_saving_an_invalid_item_type : when_working_with_the_item_type_repository
    {
        private Exception _result;

        protected override void Establish_context()
        {
            base.Establish_context();

            // Set up the return value for the mock 'session'.
            _session.Setup(s => s.Save(null)).Throws(new ArgumentNullException());
        }

        protected override void Because_of()
        {
            try
            {
                _itemTypeRepository.Save(null);
            }
            catch (Exception exception)
            {
                _result = exception;
            }
        }

        [Test]
        public void then_an_argument_null_exception_should_be_raised()
        {
            _result.ShouldBeInstanceOfType(typeof(ArgumentNullException));
        }
    }
}
