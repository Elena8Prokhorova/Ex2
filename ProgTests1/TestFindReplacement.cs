using ex2_1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProgTests
{
    [TestClass]
    public class FindingReplacement
    {
        [TestMethod]
        public void TestDoesNotHaveReplacement()
        {
            string[,] replacement = Prog.GetReplacement();
            string message = "To where it bent in the undergrowth;";
            Prog.ItemsOfPermutation expected = new Prog.ItemsOfPermutation();
            expected.source = null;
            expected.permutationCounter = 0;
            expected.itemOfUsedPermutation = 0;

            Prog.ItemsOfPermutation actual = Prog.HasReplacement(message, replacement);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestHasReplacement()
        {
            string[,] replacement = Prog.GetReplacement();
            string message = "I shall be te11ing this with a sigh";
            Prog.ItemsOfPermutation expected = new Prog.ItemsOfPermutation();
            expected.source = "l";
            expected.permutationCounter = 1;
            expected.itemOfUsedPermutation = 2;

            Prog.ItemsOfPermutation actual = Prog.HasReplacement(message, replacement);

            Assert.AreEqual(expected, actual);
        }
    }
}
