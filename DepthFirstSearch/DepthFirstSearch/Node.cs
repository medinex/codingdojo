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


        public IList<Node> AddChildren(params string[] v)
        {
            for (int i = 0; i < v.Length; i++)
            {
                var node = new Node(v[i]);
                node.AddChild(this);
                AddChild(node);
            }
            return this.Children().ToArray();
        }

        private void AddChild(Node node)
        {
            _children.Add(node);
        }

        internal List<Node> Children()
        {
            return _children;
        }
    }
}