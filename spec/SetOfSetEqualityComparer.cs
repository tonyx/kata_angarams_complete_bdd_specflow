using System.Collections.Generic;

namespace SpecFlowAnagramsKata
{
    public class SetOfSetEqualityComparer : IEqualityComparer<HashSet<string>>
    {
        public bool Equals(HashSet<string> x, HashSet<string> y)
        {
            if (x.Count != y.Count)
                return false;
            foreach (var item in x)
            {
                if (!y.Contains(item))
                    return false;
            }
            return true;
        }

        public int GetHashCode(HashSet<string> obj)
        {
            return obj.Count;
        }
    }
}