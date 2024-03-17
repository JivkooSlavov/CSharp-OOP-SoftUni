namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        private Database database;
        [SetUp]
        public void Setup()
        {
            database = new(1, 2);
        }
        [Test]
        public void CreatingDatabaseCountShouldBeCorrect()
        {
            int expectedResult = 2;

            int actualResult = database.Count;
            Assert.NotNull(database);
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestCase(new int[] {1,2,3,4,5,6,7,8})]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8,9,10,11,12,13,14,15,16 })]
        public void CreateDatabaseShouldAddElementsCorrectly(int[]data)
        {
            database = new(data);
            int[] actualResult = database.Fetch();

            Assert.AreEqual(data, actualResult);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16,17 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17,18,19 })]
        public void CreateDatabaseShouldThrowExceptionWhenCountIsMoreThanSixteen(int[] data)
        {
           
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(()
                => database = new Database(data));

            Assert.AreEqual("Array's capacity must be exactly 16 integers!", ex.Message);
        }
        [Test]
        public void DatabaseCountShouldBeCorrect()
        {
            int expectedResult = 2;

            int actualResult = database.Count;
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestCase(-3)]
        [TestCase(0)]
        public void DataBaseAddMethodShouldBeIncreaseCount(int number)
        {
            int expectedResult = 3;
            database.Add(number);
            Assert.AreEqual(expectedResult, database.Count);
        }
        [TestCase(new int[] {1,2,3,4,5,})]
        public void DatabaseAddMethodShouldAddElementsCorrectly(int[] data)
        {
            database = new Database();
            foreach (var number in data)
            {
                database.Add(number);
            }
            int[] actualResult = database.Fetch();

            Assert.AreEqual(data, actualResult);
        }
        [Test]
        public void DatabaseAddMethodShouldThrowExceptionWhenCountIsMoreThan16()
        {
            for (int i = 0; i < 14; i++)
            {
                database.Add(i);
            }

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(()
                => database.Add(321));

            Assert.AreEqual("Array's capacity must be exactly 16 integers!", ex.Message);
        }
        [Test]
        public void DatabaseRemoveMethodShouldDecreaseCount()
        {
            int expectedResult = 1;
            database.Remove();
            Assert.AreEqual(expectedResult, database.Count);
        }
        [Test]
        public void DatabaseRemoveMethodShouldRemoveElementsCorrectly()
        {
            int[] expectedResult = { };
            database.Remove();
            database.Remove();
            int[] actualResult =database.Fetch();
            Assert.AreEqual(expectedResult, actualResult);
        }
        [Test]
        public void CreateDatabaseShouldThrowExceptionIfDataIsEmpty()
        {
            database = new();

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(()
                => database.Remove());

            Assert.AreEqual("The collection is empty!", ex.Message);
        }
        [TestCase(new int[] { 1, 2, 3, 4, 5, })]
        public void DatabaseFetchMethodShouldAddElementsCorrectly(int[] data)
        {
            database = new Database(data);
 
            int[] actualResult = database.Fetch();

            Assert.AreEqual(data, actualResult);
        }
    }
}
