using System.Collections.Generic;
using System.Linq;

namespace SpecFlowAnagramsKata
{
    internal class Anagrammer
    {
        private readonly HashSet<string> _setOfWords; 
        public Anagrammer() : this(new HashSet<string>())
        {
        }

        public Anagrammer(HashSet<string> setOfWords)
        {
            _setOfWords = setOfWords;
        }

        public HashSet<HashSet<string>> Anagrams()
        {
            var toReturn = new HashSet<HashSet<string>>();
            if (_setOfWords.Count > 0)
            {
                foreach (var str in _setOfWords)
                {
                    var strWords = new HashSet<string>(){str};                    
                    foreach (var str2 in _setOfWords)
                    {
                        if (AreAnagrams(str,str2))
                        {
                            strWords.Add(str2);
                        }
                        if (!toReturn.Contains(strWords))
                            toReturn.Add(strWords);
                    }
                }
            }
            return toReturn;
        }

        public bool AreAnagrams(string str1, string str2)
        {
            if (str1.Equals(str2))
                return true;
            var lStr1 = str1.ToList();
            var lStr2 = str2.ToList();
            lStr1.Sort();
            lStr2.Sort();
            int index = 0;
            return lStr1.All(c => c == lStr2[index++]);
        }
    }
}