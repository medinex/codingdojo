using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcuseGenerator
{
    public class ExcuseGeneratorModel
    {
        private readonly IEnumerable<string> _exucsesFile1;
        private readonly IEnumerable<string> _exucsesFile3;
        private readonly IEnumerable<string> _exucsesFile2;

        //private Random 
        private const char _separator = ',';

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file1"></param>
        /// <param name="file2"></param>
        /// <param name="file3"></param>
        /// <exception cref="FileNotFoundException">when at least one of given files does not exist</exception>
        public ExcuseGeneratorModel(string file1, string file2, string file3)
        {
            //if (!FilesExist(file1, file2, file3))
            //    throw new FileNotFoundException();
            _exucsesFile1 = File.ReadAllText(file1).Split(_separator).ToList();
            _exucsesFile2 = File.ReadAllText(file2).Split(_separator).ToList();
            _exucsesFile3 = File.ReadAllText(file3).Split(_separator).ToList();

        }

        private static bool FilesExist(string file1, string file2, string file3)
        {
            return File.Exists(file1) && File.Exists(file2) && File.Exists(file3);
        }

        public IEnumerable<string> GenerateExcuse()
        {
            return new List<string>();
        }
    }
}
