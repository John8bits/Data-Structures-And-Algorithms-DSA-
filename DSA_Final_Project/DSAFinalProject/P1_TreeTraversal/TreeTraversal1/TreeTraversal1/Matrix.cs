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
    class Matrix
    {
        List<Node> nodeList = new List<Node>();
        const int MAX = 20;
       
        public Matrix() { 
            
        }

        public int GetCount() {   return nodeList.Count; }

        public int GetMax() {

            if (GetCount()>=MAX)
            {
                MessageBox.Show("You have reached the maximum number of nodes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return MAX;   
        }

        public bool addNode(Node nodeToAdd)
        {
            bool added = true;
            if (GetCount() < MAX)
                nodeList.Add(nodeToAdd);
            else
                added = false;
            return added;
        }

        public List<Node> getNodes() {
            return nodeList;  
        }


        public Node getSpecificNode(int index)
        {
            return nodeList.ElementAt(index);
        }

 
        public int getNodeIndex(int nodeName)
        {
            for (int i = 0; i < this.GetCount(); i++)
            {
                if (this.getSpecificNode(i) == null) { break; }
                if (this.getSpecificNode(i).getNodeNum() == nodeName) { return i; }
            }
            return -1;
        }

        public int getNodeIndex(String nodeName)
        {
            for (int i = 0; i < this.GetCount(); i++)
            {
                if (this.getSpecificNode(i) == null) { break; }
                if (this.getSpecificNode(i).getSName().ToLower() == nodeName.ToLower()) { return i; }
            }
            return -1;
        }

        public Node hasSelectedNode(Point p)
        {
            foreach (Node node in this.getNodes())
            {
                if (node == null) { break; }

                if (((p.X > (node.GetLocation().GetX() - (frmTreeTraversal.NODESIZE / 2))) && (p.X < (node.GetLocation().GetX() + (frmTreeTraversal.NODESIZE / 2)))) &&
                    (p.Y > (node.GetLocation().GetY() - (frmTreeTraversal.NODESIZE / 2))) && (p.Y < (node.GetLocation().GetY() + (frmTreeTraversal.NODESIZE / 2))))
                {
                    return node;
                }
            }
            return null;
        }

        public bool removeNode(Node node)
        {
            if (GetCount() > 0)
            {
                nodeList.Remove(node);
            }
            return false;
        }
    }
}
