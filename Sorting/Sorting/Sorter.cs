using System;

namespace Sorting
{
    public class Sorter
    {
        public readonly string[] unsortedArray;

        public Sorter(string[] unsortedArray)
        {
            this.unsortedArray = unsortedArray;
        }

        public long Sorted()
        {
            var countOperation = 0L;
            for (var i = 0; i < unsortedArray.Length; i++)
            {
                var current = unsortedArray[i];
                var j = i;
                while (j > 0
                       && string.Compare(unsortedArray[j - 1], current, StringComparison.Ordinal) >  0 )
                {
                    unsortedArray[j] = unsortedArray[j - 1];
                    j--;
                    countOperation += 2;
                }
                unsortedArray[j] = current;
                countOperation += 3;
            }
            return countOperation;
        }
    }
}