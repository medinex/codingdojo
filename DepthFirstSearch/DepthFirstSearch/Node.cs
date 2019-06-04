using System;
using System.Collections.Generic;

namespace DepthFirstSearch
{
    public class Node
    {
        List<Node> _children = new List<Node>();

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public Node(string n = "")
        {
            Name = n;
        }


        public void AddChildren(params string[] v)
        {
            for (int i = 0; i < v.Length; i++)
            {
                _children.Add(new Node(v[i]));
            }
        }

        internal List<Node> Children()
        {
            return _children;
        }
    }
}