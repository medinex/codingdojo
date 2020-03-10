using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcuseGenerator
{
    class DataService : IDataService
    {
        private char _separator = ',';

        public IEnumerable<IEnumerable<string>> Data { get;  }

        public DataService(string[] args)
        {
            Data = args.Select(a => File.ReadAllText(a).Split(_separator).ToList());
        }
    }
}
