using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpellingBee.Test
{
    [TestClass]
    public class AnagramLibTest
    { 
        [TestMethod]
        public void CanonicalFormRemoveDuplicate()
        {
            Assert.AreEqual("ACER", AnagramLib.CanonicalFormRemoveDuplicate("Racecar"));
            Assert.AreEqual("AB", AnagramLib.CanonicalFormRemoveDuplicate("Abba"));
            Assert.AreEqual("ACEMR", AnagramLib.CanonicalFormRemoveDuplicate("Camera"));
        }
        [TestMethod]
        public void CanonicalForm()
        {
            Assert.AreEqual("AACCERR", AnagramLib.CanonicalForm("Racecar"));
            Assert.AreEqual("AABB", AnagramLib.CanonicalForm("Abba"));
            Assert.AreEqual("AACEMR", AnagramLib.CanonicalForm("Camera"));
        }

        [TestMethod]
        public void FindAllAnagrams1()
        {
            var actual = AnagramLib.FindAllAnagrams(new List<string> { "q"});
            var x = new List<List<string>>
            { };
            CollectionAssert.AreEqual(x, actual);
        }

        void DeepEquivalent(List<List<string>> expected, List<List<string>> actual)
        {
            for (int i=0; i < expected.Count && i < actual.Count;i++)
                CollectionAssert.AreEquivalent(expected[i], actual[i]);
        }

        [TestMethod]
        public void FindAllAnagrams2()
        {
            var actual = AnagramLib.FindAllAnagrams(new List<string> {  "baab", "ba"});
            var x = new List<List<string>>
            {
                new List<string>(){"ba","baab"},
            };
            DeepEquivalent(x, actual);
        }

        [TestMethod]
        public void FindAllAnagrams()
        {
            var actual = AnagramLib.FindAllAnagrams(new List<string> {"q", "baab", "ba", "crab", "rbbbaccc"});
            var x = new List<List<string>>
            {
                new List<string>(){"ba","baab"},
                new List<string>(){ "crab", "rbbbaccc" }
            };
            DeepEquivalent(x, actual);
           
        }
    }
}
