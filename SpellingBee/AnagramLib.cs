using System;
using System.Collections.Generic;
using System.Linq;

namespace SpellingBee
{
    public class AnagramLib
    {
        public static List<List<string>> FindAllAnagramsNoLinq(List<string> wordList)
        {
            List<List<string>> list = new List<List<string>>();
            foreach (var list1 in wordList.GroupBy(CanonicalFormRemoveDuplicate).Where(g => g.Count() > 1).Select(g => g.OrderBy(w => w).ToList()).OrderBy(g => g.First())) list.Add(list1);
            return list;
        }
        public static String CanonicalFormRemoveDuplicateNoLinq(string s)
        {
            return new string(Enumerable.Distinct(s.ToUpper().ToCharArray()).OrderBy(c => c).ToArray());
        }

        public static String CanonicalForm(string s)
        {
            return new string(s.ToUpper().ToCharArray()
                .OrderBy(c => c).ToArray());
        }
        public static String CanonicalFormRemoveDuplicate(string s)
        {
            return new string(s.ToUpper().ToCharArray().Distinct().OrderBy(c => c).ToArray());
        }
        public static List<List<string>> FindAllAnagrams(List<string> wordList)
        {
            return wordList.GroupBy(CanonicalFormRemoveDuplicate)
                .Where(g => g.Count() > 1)
                .Select(g => g.OrderBy(w => w).ToList())
                .OrderBy(g => g.First())
                .ToList();
        }
    }
}
