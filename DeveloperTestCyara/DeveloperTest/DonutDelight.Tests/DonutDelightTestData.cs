using System.Collections;
using System.Collections.Generic;

namespace DonutDelight.Tests
{
    public class DonutDelightTestData
    {
        private static readonly List<int> invalidOrderSizes = new List<int> { 1, 2, 3, 5, 7, 11 };

        private static List<int> sampleValidValue = new List<int> { 21, 22, 4, 16, 77, 89 , 103, 371 };

        public static IEnumerable InvalidOrderSizes
        {
            get
            {
                foreach(var i in invalidOrderSizes)
                {
                    yield return i;
                }
            }
        }

        public static IEnumerable SampleValidValue
        {
            get
            {
                foreach (var i in sampleValidValue)
                {
                    yield return i;
                }
            }
        }

        public static IEnumerable InvalidInput
        {
            get
            {
                yield return 0;
                yield return -1;
            }
        }
    }
}