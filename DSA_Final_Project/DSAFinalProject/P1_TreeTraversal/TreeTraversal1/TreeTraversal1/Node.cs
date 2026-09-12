using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
namespace TreeTraversal1
{
    class Node
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int nodeIndex { get; set; }
        public int visited { get; set; }
        public int currentDistance { get; set; }
        public String currentpath { get; set; }
        public Node predecessor { get; set; }
        public int Cost { get; set; }
        public int HeuristicValue { get; set; }
        public int Fn { get; set; }

        //public List<Node> Neighbors { get; set; }

        Location location;
        public int nodeNum;
        private String sName = "ABCDEFGHIJKLMNOPQRST";
        private String nodeStatus;


        public List<Node> adjacentList = new List<Node>();
        public Node()
        {
            location = new Location(0, 0);
            SetNodeNum(0);
        }

        public Node(Node n)
            : this(n.X, n.Y, n.nodeNum)
        {
            this.Cost = n.Cost;
            this.adjacentList = n.AdjacentList;
        }
        public Node(int x, int y, int nodeNum)
        {
            X = x;
            Y = y;
            location = new Location(x, y);
            nodeIndex = nodeNum;
            SetNodeNum(nodeNum);
        }

        public Node(int x, int y)
        {
            X = x;
            Y = y;
            nodeIndex = nodeNum;
            location = new Location(x, y);
            
        }
        public Node(Location loc, int nodeNum)
        {
            location = new Location(loc.GetX(), loc.GetY());
            SetNodeNum(nodeNum);
        }

        public String getSName()
        {
            return this.sName.Substring(nodeIndex, 1);
        }

        public String getNodeStatus()
        {
            return nodeStatus;
        }

        public void setNodeStatus(String ns)
        {
           nodeStatus = ns;
        }

        public void SetLocation(int x, int y)
        {
            location.SetX(x);
            location.SetY(y);

        }
        public void  SetNodeNum(int nodeNum)
        {
            this.nodeNum = nodeNum;
        }

        public Location GetLocation() { 
            return location; 
        }
        public int getNodeNum()
        {
            return nodeNum; 
        }
        public Point getNodePoint()
        {
            return new Point(X, Y);
        }

        public int distanceTo(Point pt)
        {
            return (int)Math.Sqrt(Math.Pow(pt.X - X, 2) + Math.Pow(pt.Y - Y, 2));
        }

        public List<Node> AdjacentList
        {
            get
            {
                return adjacentList;
            }
        }

        public void removeAdjacent(Node point)
        { 
          adjacentList.RemoveAt(adjacentList.IndexOf(point));
        }
        
        public bool isConnected(Node node)
        {
            bool ret = false;

            if (node.nodeIndex == nodeIndex) return false;

            List<Node>.Enumerator itr = adjacentList.GetEnumerator();
            Node pt = null;
            while (itr.MoveNext())
            {
                pt = itr.Current;
              
                if (pt.nodeIndex == node.nodeIndex)
                {
                    return true;
                }
               
            }

            return ret;
        }


        
        public bool addAdjacent(Node point)
        {
            bool ret = true;

            if (point.nodeIndex  == nodeIndex) return false;

            if (0 == adjacentList.Count)
            {
                adjacentList.Add(point);
                return true;
            }

            List<Node>.Enumerator itr = adjacentList.GetEnumerator();
            Node pt = null;
            while (itr.MoveNext())
            {
                pt = itr.Current;
                if (point.nodeIndex > pt.nodeIndex)
                {
                    continue;
                }
                else if (pt.nodeIndex == point.nodeIndex)
                {
                    return false;
                }
                else if (point.nodeIndex < pt.nodeIndex)
                {
                    adjacentList.Insert(adjacentList.IndexOf(pt), point);
                    return true;
                }
            }

            adjacentList.Add(point);

            return ret;
        }
        
    }
}
