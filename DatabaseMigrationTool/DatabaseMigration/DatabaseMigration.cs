using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DatabaseMigration
{
    public static class XmlDocumentExtensions
    {
        public static void IterateThroughAllNodes(this XmlDocument doc, Action<XmlNode> elementVisitor)
        {
            if (doc != null && elementVisitor != null)
            {
                foreach (XmlNode node in doc.ChildNodes)
                {
                    doIterateNode(node, elementVisitor);
                }
            }
        }

        private static void doIterateNode(XmlNode node, Action<XmlNode> elementVisitor)
        {
            elementVisitor(node);

            foreach (XmlNode childNode in node.ChildNodes)
            {
                doIterateNode(childNode, elementVisitor);
            }
        }
    }
    public class DatabaseMigration
    {
        public XmlDocument LoadDocument(string pathToFile)
        {
            if (string.IsNullOrWhiteSpace(pathToFile) || string.IsNullOrEmpty(pathToFile))
            {
                throw new ArgumentException("Invalid path to file", nameof(pathToFile));
            }

            XmlDocument doc = new XmlDocument();
            doc.Load(pathToFile);
            return doc;
        }

        public IList<string> ListChangesets(XmlDocument doc)
        {
            IList<string> simpleNodes = new List<string>();

            doc.IterateThroughAllNodes(
            delegate (XmlNode node)
            {
                if(node.Name == "#text" || node.Name == "#comment") { } else simpleNodes.Add(node.Name);
            });

            return simpleNodes;
        }
    }
}
