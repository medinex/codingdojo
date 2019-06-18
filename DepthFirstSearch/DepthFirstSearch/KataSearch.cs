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
            var list = new List<string>();
            Traverse(node, list, Enumerable.Empty<Node>());
            return list.ToArray();
        }

        private static void Traverse(Node node, List<string> nodes, IEnumerable<Node> visited)
        {
            nodes.Add(node.Name);
            var children = node.Children();
            var one = children.Except(visited).FirstOrDefault();

            if(one != null)
            {
                visited = visited.Append(one);
                Traverse(one, nodes, visited);
                Traverse(node, nodes, visited);
            }

        }


    }
}
