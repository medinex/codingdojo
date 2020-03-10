using System;
using System.Collections.Generic;

namespace BofhExuseGenerator
{

    public class Generator
    {
        private Random _random = new Random();

        public string CreateExcuse(List<string> firstList, List<string> secondList, List<string> thirdList, List<string> fourthList)
        {
            if (firstList is null)
            {
                throw new ArgumentNullException(nameof(firstList));
            }

            if (secondList is null)
            {
                throw new ArgumentNullException(nameof(secondList));
            }

            if (thirdList is null)
            {
                throw new ArgumentNullException(nameof(thirdList));
            }

            if (fourthList is null)
            {
                throw new ArgumentNullException(nameof(fourthList));
            }

            var index1 = _random.Next(0, firstList.Count - 1);
            var index2 = _random.Next(0, secondList.Count - 1);
            var index3 = _random.Next(0, thirdList.Count - 1);
            var index4 = _random.Next(0, fourthList.Count - 1);
            return $"{firstList[index1]} {secondList[index2]} {thirdList[index3]} {fourthList[index4]}";
        }

    }
}
