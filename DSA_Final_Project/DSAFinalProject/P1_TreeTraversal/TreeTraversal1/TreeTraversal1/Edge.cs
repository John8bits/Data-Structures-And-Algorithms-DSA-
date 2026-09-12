using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TreeTraversal1
{
    class Edge
    {
          
        public int length=0;
        public Node nodeFrom;
        public Node nodeTo;
        public bool Directed { get; set; }
        public string Name { get; set; }
        public Edge() { 
        
        }
        public Edge(Node nodeFrom, Node nodeTo, bool directed)
        {
            this.nodeFrom = nodeFrom;
            this.nodeTo = nodeTo;
            Directed = false;
            length = nodeFrom.distanceTo(nodeTo.getNodePoint());
            Name = ""+ nodeFrom.nodeIndex + nodeTo.nodeIndex;
        }
        public Edge(Node nodeFrom, Node nodeTo, int dis)
        {
            length = dis;
        }

        public static int SortEdgesByLength(Edge edge1, Edge edge2)
        {
            return edge1.length.CompareTo(edge2.length);
        }

        public bool Equals(Edge edge2)
        {
            if ((this.nodeFrom.getNodePoint().Equals(edge2.nodeFrom.getNodePoint())) &&
                (this.nodeTo.getNodePoint().Equals(edge2.nodeTo.getNodePoint()))
                )
            {
                return true;
            }
            else if (!this.Directed && !edge2.Directed &&
                        (this.nodeTo.getNodePoint().Equals(edge2.nodeFrom.getNodePoint())) &&
                        (this.nodeFrom.getNodePoint().Equals(edge2.nodeTo.getNodePoint()))
                )
            {
                return true;
            }
            return false;
        }
    }
}
