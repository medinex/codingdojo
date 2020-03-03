using System;
using System.Collections.Generic;
using System.Text;

namespace BofhExuseGenerator
{
    public class Resource
    {
        public static List<string> GetListNo(int n)
        {
            return GetFirstList(); 
  }
        public static List<string> GetFirstList()
        {

            return new List<string>  {
                "Temporary",
                "Intermittant",
                "Partial",
                "Redundant",
                "Total",
                "Multiplexed",
                "Inherent",
                "Duplicated",
                "Dual - Homed",
                "Synchronous",
                "Bidirectional",
                "Serial",
                "Asynchronous",
                "Multiple",
                "Replicated",
                "Non - Replicated",
                "Unregistered",
                "Non - Specific",
                "Generic",
                "Migrated",
                "Localised",
                "Resignalled",
                "Dereferenced",
                "Nullified",
                "Aborted",
                "Serious",
                "Minor",
                "Major",
                "Illegal",
                "Insufficient",
                "Viral",
                "Extraneous",
                "Unsupported",
                "Outmoded",
                "Legacy",
                "Permanent",
                "Invalid",
                "Deprecated",
                "Virtual",
                "Unreportable",
                "Undetermined",
                "Undiagnosable",
                "Unfiltered",
                "Static",
                "Dynamic",
                "Delayed",
                "Immediate",
                "Nonfatal",
                "Fatal",
                "Non-Valid",
                "Unvalidated",
                "Non-Static",
                "Unreplicatable",
                "Non-Serious"
                    };
        }
    }
}
