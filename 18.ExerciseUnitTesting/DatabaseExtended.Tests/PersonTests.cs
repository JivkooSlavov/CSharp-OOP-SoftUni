using ExtendedDatabase;

namespace DatabaseExtended.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class PersonTests
    {
        private const string ValidUserName = "pesho123";
        private const long ValidId = 100001;

        [Test]

        public void Ctor_WithValidParameters_CreateNewInstance()
        {
            Person person = new Person(ValidId, ValidUserName);
            Assert.IsNotNull(person);
            Assert.AreEqual(person.Id, ValidId);
            Assert.AreEqual(person.UserName, ValidUserName);

        }
    }
}