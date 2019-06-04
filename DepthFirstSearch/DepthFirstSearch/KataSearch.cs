using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepthFirstSearch
{
    public class KataSearch
    {
        public static object WhereAreWe(Node node)
        {
            return node.Name;
        }

        public static List<Node> WhereAreTheExists(Node node)
        {
            return node.Children();
        }

        
        public static string[] Traverse(Node node)
        {
            return null;
        }

    }
}
