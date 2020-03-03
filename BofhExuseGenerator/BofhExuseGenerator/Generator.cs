using System;
using System.Collections.Generic;

namespace BofhExuseGenerator
{

    public class Generator
    {

        public string CreateExcuse(int first, int second, int third, int fourth)
        {
            var firstList = Resource.GetFirstList();
            var secondList = Resource.GetFirstList();
            var thirdList = Resource.GetFirstList();
            var fourthList = Resource.GetFirstList();
            return $"{firstList[first]}";
        }

    }
}
