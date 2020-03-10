using System.Collections;
using System.Collections.Generic;

namespace ExcuseGenerator
{
    public interface IDataService
    {
        IEnumerable<IEnumerable<string>> Data { get; }
    }
}