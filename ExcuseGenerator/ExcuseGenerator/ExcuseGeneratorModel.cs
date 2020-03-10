using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcuseGenerator
{
    public class ExcuseGeneratorModel
    {

        private readonly IDataService _dataService;
        private readonly IRandomNumberProvider _random;
        

        public ExcuseGeneratorModel(IDataService dataService, IRandomNumberProvider randomNumberProvider)
        {
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
            _random = randomNumberProvider ?? throw new ArgumentNullException(nameof(randomNumberProvider));
        }

        public string GenerateExcuse()
        {
            string concat = string.Empty;

            foreach(var data in _dataService.Data)
            {
                var count = data.ToList().Count;

                var randomString = data.ToList()[_random.GenerateRandom(0, count - 1)];

                concat = string.Format(CultureInfo.CurrentCulture, "{0} {1}", concat, randomString);
            }

            return concat;
        }
    }
}
