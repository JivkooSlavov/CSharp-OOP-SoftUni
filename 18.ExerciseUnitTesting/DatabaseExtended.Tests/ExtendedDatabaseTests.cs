using System;
using ExtendedDatabase;

namespace DatabaseExtended.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private const int MaxPeople = 17;
        private const string AddRangeExpectedException = "Provided data length should be in range [0..16]!";
        private const string AddMaxNumberReacheedExpectedException = "Array's capacity must be exactly 16 integers!";
        private const string UserNameExistExpectedException = "There is already user with this username!";
        private const string IdExistExpectedException = "There is already user with this Id!";
        private const string FindByUserNameNullArg = "Username parameter is null!";
        private const string FindByMissingUserName = "No user is present by this username!";
        private const string FindByIdCantBeNegativeNumberThrowException = "Id should be a positive number!";
        private const string ValidUserNamePesho = "pesho123";
        private const long ValidIdPesho = 100001;
        private const string ValidUserNameIvan = "ivan123";
        private const long ValidIdIvan = 100002;
        Database sut;


        [SetUp]
        public void SetUp()
        {
            Person pesho = new Person(ValidIdPesho, ValidUserNamePesho);
            Person ivan = new Person(ValidIdIvan, ValidUserNameIvan);
            Person[] people = new Person[] { pesho, ivan };
            sut = new Database(people);
        }

        [Test]
        public void Ctor_EmptyWithValidParameters_CreatesNewInstance()
        {
            Database db = new Database();
            Assert.That(db, Is.Not.Null);
            Assert.That(db.Count, Is.EqualTo(0));
        }

        [Test]
        public void Ctor_WithValidParameters_CreatesNewInstance()
        {
          Assert.That(sut, Is.Not.Null);
          Assert.AreEqual(2, sut.Count);
        }
        [Test]
        public void Ctor_WithToManyPeople_ThrowException()
        {
            Person[] tooManyPeople = new Person[MaxPeople];
            for (int i = 0; i < MaxPeople; i++)
            {
                tooManyPeople[i] = new Person(ValidIdPesho+i, $"{ValidIdPesho}-i");
            }

            ArgumentException ex = Assert.Throws<ArgumentException>(
                () => new Database(tooManyPeople));
            Assert.AreEqual(AddRangeExpectedException, ex.Message);
        }
        [Test]
        public void Add_HappyPath_AddsNewPerson()
        {
            Person maria = new Person(ValidIdIvan + 1, "maria");
            sut.Add(maria);
            Assert.AreEqual(3, sut.Count);
        }
        [Test]
        public void Add_DatabaseIsFull_ThrowException()
        {
            for (int i = sut.Count; i < 16; i++)
            {
                 sut.Add(new Person(ValidIdPesho + i, $"ValidIdPesho-{i}"));
            }

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(
                () => sut.Add(new Person(43344, "zhivko")));
            Assert.AreEqual(AddMaxNumberReacheedExpectedException, ex.Message);
        }
        [Test]
        public void Add_DatabaseWithSameName_ThrowException()
        {
            for (int i = sut.Count; i < 14; i++)
            {
                sut.Add(new Person(ValidIdPesho + i, $"ValidIdPesho-{i}"));
            }

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(
                () => sut.Add(new Person(10000, "pesho123")));
            Assert.AreEqual(UserNameExistExpectedException, ex.Message);
        }
        [Test]
        public void Add_DatabaseWithSameId_ThrowException()
        {
            for (int i = sut.Count; i < 14; i++)
            {
                sut.Add(new Person(ValidIdPesho + i, $"ValidIdPesho-{i}"));
            }

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(
                () => sut.Add(new Person(100001, "pesho1235252")));
            Assert.AreEqual(IdExistExpectedException, ex.Message);
        }
        [Test]
        public void FindByUserName_HappyPath_ReturnUser()
        {
            Person peshoFound = sut.FindByUsername((ValidUserNamePesho));
            Assert.IsNotNull(peshoFound);
            Assert.AreEqual(ValidUserNamePesho, peshoFound.UserName);
            Assert.AreEqual(ValidIdPesho, peshoFound.Id);
        }
       [Test]
        public void FindByUserNameIsNull_ThrowException()
        {
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(
                () => sut.FindByUsername(null));
        }
        [Test]
        public void FindByUseIsWhiteSpace_ThrowException()
        {
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(
                () => sut.FindByUsername("asashfjasfjasjf"));
        }
        [Test]
        public void FindById_HappyPath_ReturnUser()
        {
            Person peshoFound = sut.FindById((ValidIdPesho));
            Assert.IsNotNull(peshoFound);
            Assert.AreEqual(ValidUserNamePesho, peshoFound.UserName);
            Assert.AreEqual(ValidIdPesho, peshoFound.Id);
        }
        [Test]
        public void FindByUserIdIsNegative_ThrowException()
        {
            ArgumentOutOfRangeException ex = Assert.Throws<ArgumentOutOfRangeException>(
                () => sut.FindById(-1));
        }
        [Test]
        public void FindByUserIdMissing_ThrowException()
        {
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(
                () => sut.FindById(9999999));
        }
        [Test]
        public void Remove_HappyPath_RemoveUser()
        {
            sut.Remove();
            Assert.AreEqual(1 , sut.Count);
        }
        [Test]
        public void Remove_CantRemove_RemoveUser()
        {
            sut.Remove();
            sut.Remove();
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(
                () => sut.Remove());

        }
    }
}