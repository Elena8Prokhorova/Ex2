using ex2_1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProgTests
{
    [TestClass]
    public class CorrectionMessage
    {
        [TestMethod]
        public void TestWithoutCorrection()
        {
            string[,] replacement = Prog.GetReplacement();
            string message = "To where it bent in the undergrowth;";
            string expected = "To where it bent in the undergrowth;";

            string actual = Prog.MessageCorrection(message, replacement);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestWithCorrection()
        {
            string[,] replacement = Prog.GetReplacement();
            string message = "Two roads diverged in a d12324344rgg6f5g6gdf2ddjf, and I";
            string expected = "Two roads diverged in a wood, and I";

            string actual = Prog.MessageCorrection(message,replacement);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestDefaultMessage()
        {
            string[,] replacement = Prog.GetReplacement();
            string message = "An other text";
            string expected = null;

            string actual = Prog.MessageCorrection(message, replacement);

            Assert.AreEqual(expected, actual);
        }
    }
}