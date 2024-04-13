using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace UniversityLibrary.Test
{
    using NUnit.Framework;
    using System.Text;

    public class Tests
    {
        private TextBook textBook;
        private UniversityLibrary library;
        [SetUp]
        public void Setup()
        {
            textBook = new TextBook("Notebook", "Zhivko", "romance");
            library = new UniversityLibrary();
        }

        [Test]
        public void Test_Ctor_TextBook()
        {
            Assert.IsNotNull(textBook);
            Assert.AreEqual("Notebook", textBook.Title);
            Assert.AreEqual("Zhivko", textBook.Author);
            Assert.AreEqual("romance", textBook.Category);
            Assert.AreEqual(null, textBook.Holder);
            Assert.AreEqual(0, textBook.InventoryNumber);
        }

        [Test]
        public void Test_ToStringTextBook()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Book: Notebook - 0");
            sb.AppendLine($"Category: romance");
            sb.AppendLine($"Author: Zhivko");
            string expected = sb.ToString().TrimEnd();
            string result = textBook.ToString();
            Assert.AreEqual( expected, result );    
        }
        [Test]
        public void Test_Library_AddTextBook()
        {
           string result = library.AddTextBookToLibrary(textBook);
           Assert.AreEqual(1, textBook.InventoryNumber);
           Assert.AreEqual(1, library.Catalogue.Count);
           StringBuilder sb = new StringBuilder();
           sb.AppendLine($"Book: Notebook - 1");
           sb.AppendLine($"Category: romance");
           sb.AppendLine($"Author: Zhivko");
           string expected = sb.ToString().TrimEnd();
           Assert.AreEqual(expected, result);

        }
        [Test]
        public void Test_Library_LoanBook()
        {
            library.AddTextBookToLibrary(textBook);
            TextBook textBook1 = new TextBook("Up", "Teddy", "comedy");
            string result = library.LoanTextBook(1, "Danny");
            string expected = $"Notebook loaned to Danny.";
            Assert.AreEqual(expected, result);
            string result1 = library.LoanTextBook(1, "Danny");
            string expected1 = $"Danny still hasn't returned Notebook!";
            Assert.AreEqual(expected1, result1);
        }
        [Test]
        public void Test_Library_ReturnBook()
        {
            library.AddTextBookToLibrary(textBook);
            TextBook textBook1 = new TextBook("Up", "Teddy", "comedy");
            string result = library.ReturnTextBook(1);
            string expected = "Notebook is returned to the library.";
            Assert.AreEqual(expected, result);
            Assert.AreEqual(textBook.Holder, string.Empty);
        }
    }
}