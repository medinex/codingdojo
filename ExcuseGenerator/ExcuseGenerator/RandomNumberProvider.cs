using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcuseGenerator
{
    public class RandomNumberProvider : IRandomNumberProvider
    {
        private readonly Random random = new Random();

        int IRandomNumberProvider.GenerateRandom(int min, int max)
        {
            throw new NotImplementedException();
        }
    }
}
