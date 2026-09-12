using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Xml.Linq;
using System.Threading.Tasks;

namespace TreeTraversal1
{
    public partial class frmTreeTraversal : Form
    {
        public bool checkedDir;
        private Dictionary<string, Edge> edgesDict;
        private Adjacency adjacencyMatrix;
        Stack s = new Stack();  //DFS
        Queue<Node> q = new Queue<Node>(); //BFS
        Graphics g;
        Matrix tree;
        byte clickNodeCount = 0;
        Node clickedNode;
        int i;
        public const int NODESIZE = 30;
        public String searchPath;
        StringFormat sf = new StringFormat();
        Bitmap bm;
        bool isLetter, fromFile;
        private String sName = "ABCDEFGHIJKLMNOPQRST";
        Node sNode = null, endNode = null;

        public frmTreeTraversal()
        {
            InitializeComponent();
            this.adjacencyMatrix = new Adjacency();
            setDefault();
            InitializeDataGridView();
        }

        private void setDefault()
        {
            fromFile = false;
            edgesDict = new Dictionary<string, Edge>();
            bm = new Bitmap(graphingArea.Width, graphingArea.Height);
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            tree = new Matrix();

            g = graphingArea.CreateGraphics();

            adjacencyMatrix.Items.Clear();
            adjacencyMatrix.init();
            graphingArea.Image = null;
            this.SuspendLayout();
            this.Controls.AddRange(new Control[] { this.adjacencyMatrix });

            adjacencyMatrix.Top = 57;
            adjacencyMatrix.Left = 760;
            adjacencyMatrix.GridLines = true;
            this.Width = 1200;

            cmbStartSPNode.Items.Clear();
            cmbEndSPNode.Items.Clear();

            // Set default selections
            if (tree.getNodes().Count > 0)
            {
                cmbStartSPNode.SelectedIndex = 0;
                if (tree.getNodes().Count > 1)
                    cmbEndSPNode.SelectedIndex = 1;
            }
        }

        private void graphingAreaMouseClicked(object sender, MouseEventArgs e)
        {
            Point mouseLocation = e.Location;
            Node selNode = tree.hasSelectedNode(mouseLocation);

            if (e.Button == MouseButtons.Left)
            {
                if ((selNode != null && clickedNode == selNode) || (clickedNode != null && selNode == null))
                {
                    clickedNode.setNodeStatus("Cancel");
                    drawNode(clickedNode, clickedNode.getNodeStatus(), isLetter);
                }
                else if (selNode != null && clickNodeCount < 2)
                {
                    clickNodeCount++;
                    if (clickNodeCount == 2)
                    {
                        disOrConnectNode(clickedNode, selNode, !clickedNode.isConnected(selNode));
                    }
                    else
                    {
                        selNode.setNodeStatus("Selected");
                        drawNode(selNode, selNode.getNodeStatus(), isLetter);
                        clickedNode = selNode;
                    }
                }
                else if (!isCascading(mouseLocation))
                {
                    Node nodeToAdd = new Node(mouseLocation.X, mouseLocation.Y, tree.GetCount());
                    nodeToAdd.setNodeStatus("Add");
                    drawNode(nodeToAdd, nodeToAdd.getNodeStatus(), isLetter);
                    /*
                    if (tree.GetCount() > tree.GetMax())
                    {
                        MessageBox.Show("You have reached the maximum number of nodes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }*/
                }
                else
                {
                    MessageBox.Show("Cascading Nodes!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (tree.hasSelectedNode(mouseLocation) != null)
                {
                    deleteNode(tree.hasSelectedNode(mouseLocation));
                    clickedNode = null;
                    clickNodeCount = 0;
                }
            }
        }

        private void deleteNode(Node node)
        {
            try
            {
                // Disconnect from all adjacent nodes
                for (int i = 0; i < tree.GetCount(); i++)
                {
                    if (i < tree.getNodes().Count && tree.getNodes().ElementAt(i).isConnected(node))
                    {
                        disOrConnectNode(node, tree.getNodes().ElementAt(i), false);
                    }
                }

                // Remove from adjacency matrix
                int nodeNum = node.getNodeNum();
                if (nodeNum + 1 < adjacencyMatrix.Columns.Count)
                {
                    adjacencyMatrix.Columns.RemoveAt(nodeNum + 1);
                }

                // Remove the row from adjacency matrix
                if (nodeNum < adjacencyMatrix.Items.Count)
                {
                    adjacencyMatrix.Items.RemoveAt(nodeNum);
                }

                // Remove from tree
                tree.removeNode(node);

                node.setNodeStatus("Delete");
                drawNode(node, node.getNodeStatus(), isLetter);

                // Rebuild adjacency matrix after deletion
                RebuildAdjacencyMatrix();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting node: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // NEW METHOD: Rebuild adjacency matrix after node deletion
        private void RebuildAdjacencyMatrix()
        {
            try
            {
                // Clear current adjacency matrix
                adjacencyMatrix.Items.Clear();
                adjacencyMatrix.Columns.Clear();

                // Add first column for node names
                adjacencyMatrix.Columns.Add("Node", "Node");

                // Add columns for each node
                foreach (Node n in tree.getNodes())
                {
                    if (isLetter)
                        adjacencyMatrix.Columns.Add(n.getSName(), n.getSName());
                    else
                        adjacencyMatrix.Columns.Add(n.getNodeNum().ToString(), n.getNodeNum().ToString());
                }

                // Add rows for each node
                foreach (Node n in tree.getNodes())
                {
                    ListViewItem item;
                    if (isLetter)
                        item = new ListViewItem(n.getSName());
                    else
                        item = new ListViewItem(n.getNodeNum().ToString());

                    // Add subitems for all nodes
                    for (int i = 0; i < tree.getNodes().Count; i++)
                    {
                        item.SubItems.Add("0");
                    }
                    adjacencyMatrix.Items.Add(item);
                }

                // Re-populate connections
                foreach (Node fromNode in tree.getNodes())
                {
                    foreach (Node toNode in tree.getNodes())
                    {
                        if (fromNode.isConnected(toNode))
                        {
                            int fromIndex = tree.getNodes().IndexOf(fromNode);
                            int toIndex = tree.getNodes().IndexOf(toNode);

                            if (fromIndex >= 0 && toIndex >= 0 &&
                                fromIndex < adjacencyMatrix.Items.Count &&
                                toIndex + 1 < adjacencyMatrix.Items[fromIndex].SubItems.Count)
                            {
                                adjacencyMatrix.Items[fromIndex].UseItemStyleForSubItems = false;
                                adjacencyMatrix.Items[fromIndex].SubItems[toIndex + 1].Text = "1";
                                adjacencyMatrix.Items[fromIndex].SubItems[toIndex + 1].ForeColor = Color.Crimson;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error rebuilding adjacency matrix: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool isCascading(Point p)
        {
            foreach (Node node in tree.getNodes())
            {
                if (node == null) { break; }

                if (((p.X > (node.GetLocation().GetX() - NODESIZE)) && (p.X < (node.GetLocation().GetX() + NODESIZE))) &&
                    (p.Y > (node.GetLocation().GetY() - NODESIZE)) && (p.Y < (node.GetLocation().GetY() + NODESIZE)))
                {
                    return true;
                }
            }
            return false;
        }

        private void disOrConnectNode(Node fromThisNode, Node toThisNode, bool isConnectedNode)
        {
            using (Pen pn = new Pen(Color.Red, 3))
            using (SolidBrush brush3 = new SolidBrush(Color.Black))
            using (Font font3 = new Font(FontFamily.GenericSerif, 10))
            {
                pn.StartCap = System.Drawing.Drawing2D.LineCap.NoAnchor;

                if (chkboxDirected.Checked)
                    pn.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
                else
                    pn.EndCap = System.Drawing.Drawing2D.LineCap.RoundAnchor;

                int x = (fromThisNode.GetLocation().GetX() + toThisNode.GetLocation().GetX()) / 2;
                int y = (fromThisNode.GetLocation().GetY() + toThisNode.GetLocation().GetY()) / 2;

                if (isConnectedNode)
                {
                    using (g = Graphics.FromImage(bm))
                    {
                        fromThisNode.addAdjacent(toThisNode);

                        if (!chkboxDirected.Checked)
                            toThisNode.addAdjacent(fromThisNode);

                        g.DrawLine(pn, getPointOnCircle(fromThisNode.getNodePoint(), toThisNode.getNodePoint()),
                                   getPointOnCircle(toThisNode.getNodePoint(), fromThisNode.getNodePoint()));
                        Edge con = new Edge(fromThisNode, toThisNode, chkboxDirected.Checked);

                        edgesDict.Add(con.Name, con);

                        if (!fromFile && !chkboxDirected.Checked)
                        {
                            Edge edgeRv = new Edge(toThisNode, fromThisNode, chkboxDirected.Checked);
                            edgesDict.Add(edgeRv.Name, edgeRv);
                        }

                        using (Pen pn2 = new Pen(Color.Red, 2))
                        {
                            updateAdjacencyMatrix(fromThisNode, toThisNode);
                            g.DrawString(con.length + "", font3, brush3, new Point(x, y));

                            if (!chkboxDirected.Checked)
                                refreshNodes(g);
                        }
                    }
                    graphingArea.Image = bm;
                }
                else // disconnect if has connection 
                {
                    using (Font font2 = new Font(FontFamily.GenericSerif, 11))
                    using (Pen pnWhite = new Pen(Color.White, 8))
                    using (SolidBrush whiteBrush = new SolidBrush(Color.White))
                    {
                        using (g = Graphics.FromImage(bm))
                        {
                            fromThisNode.removeAdjacent(toThisNode);
                            toThisNode.removeAdjacent(fromThisNode);
                            Edge con = new Edge(fromThisNode, toThisNode, chkboxDirected.Checked);

                            // FIXED: Safe removal from edgesDict
                            List<string> keysToRemove = new List<string>();
                            foreach (var kvp in edgesDict)
                            {
                                if (kvp.Value.nodeFrom == con.nodeFrom && kvp.Value.nodeTo == con.nodeTo)
                                    keysToRemove.Add(kvp.Key);
                            }
                            foreach (string key in keysToRemove)
                            {
                                edgesDict.Remove(key);
                            }

                            if (!chkboxDirected.Checked)
                            {
                                Edge edgeRv = new Edge(toThisNode, fromThisNode, chkboxDirected.Checked);
                                keysToRemove.Clear();
                                foreach (var kvp in edgesDict)
                                {
                                    if (kvp.Value.nodeFrom == edgeRv.nodeFrom && kvp.Value.nodeTo == edgeRv.nodeTo)
                                        keysToRemove.Add(kvp.Key);
                                }
                                foreach (string key in keysToRemove)
                                {
                                    edgesDict.Remove(key);
                                }
                            }

                            Rectangle rect = new Rectangle(x - (NODESIZE / 2), y - (NODESIZE / 2), NODESIZE + 10, NODESIZE + 10);
                            g.FillPie(whiteBrush, rect, 0, 360);
                            g.DrawLine(pnWhite, getPointOnCircle(fromThisNode.getNodePoint(), toThisNode.getNodePoint()),
                                       getPointOnCircle(toThisNode.getNodePoint(), fromThisNode.getNodePoint()));
                            g.DrawString(con.length + "", font3, whiteBrush, new Point(x, y));
                            refreshNodes(g);
                            updateAdjacencyMatrixRemove(fromThisNode, toThisNode);
                            clickNodeCount = 0;
                        }
                    }
                }
                fromThisNode.setNodeStatus("Cancel");
                drawNode(fromThisNode, fromThisNode.getNodeStatus(), isLetter);
            }
        }

        private PointF getPointOnCircle(PointF p1, PointF p2)
        {
            PointF Pointref = PointF.Subtract(p2, new SizeF(p1));
            double degrees = Math.Atan2(Pointref.Y, Pointref.X);
            double cosx1 = Math.Cos(degrees);
            double siny1 = Math.Sin(degrees);

            double cosx2 = Math.Cos(degrees + Math.PI);
            double siny2 = Math.Sin(degrees + Math.PI);

            return new PointF((int)(cosx1 * (float)(NODESIZE / 2) + (float)p1.X),
                            (int)(siny1 * (float)(NODESIZE / 2) + (float)p1.Y));
        }

        private async Task DFS(Node nodeD)
        {
            using (Font font = new Font(FontFamily.GenericSansSerif, 2))
            using (Graphics graphics = graphingArea.CreateGraphics())
            using (Pen pen = new Pen(Color.White, 6))
            using (SolidBrush brush = new SolidBrush(Color.Black))
            {
                nodeD.visited = i++;

                foreach (Node conNode in nodeD.AdjacentList)
                {
                    if (conNode.visited == 0)
                    {
                        Edge con = new Edge(conNode, nodeD, chkboxDirected.Checked);
                        int x = (conNode.GetLocation().GetX() + nodeD.GetLocation().GetX()) / 2;
                        int y = (conNode.GetLocation().GetY() + nodeD.GetLocation().GetY()) / 2;

                        using (g = Graphics.FromImage(bm))
                        {
                            graphics.DrawLine(pen, conNode.getNodePoint(), nodeD.getNodePoint());
                            graphics.DrawString(con.length + " ", font, brush, new Point(x, y));
                            refreshNodes(graphics);
                            colorNode(conNode);

                            if (isLetter)
                                searchPath += ("-" + conNode.getSName());
                            else
                                searchPath += ("-" + conNode.nodeIndex);

                            txtSearchPath.Text = searchPath;
                            await Task.Delay(1000); //returns no value
                            await DFS(conNode);
                        }
                    }
                }
            }
        }

        private async Task BFS(Node nodeB, Node endN)
        {
            using (Font font = new Font(FontFamily.GenericSansSerif, 2))
            using (Graphics graphics = graphingArea.CreateGraphics())
            using (Pen pen = new Pen(Color.White, 6))
            using (SolidBrush brush = new SolidBrush(Color.Black))
            {
                nodeB.visited = i++;
                q.Enqueue(nodeB);

                while (q.Count != 0)
                {
                    Node ye = q.Dequeue();

                    foreach (Node nd in ye.AdjacentList)
                    {
                        if (nd.visited == 0)
                        {
                            nd.visited = i++;
                            q.Enqueue(nd);

                            Edge con = new Edge(nd, ye, chkboxDirected.Checked);
                            int x = (nd.GetLocation().GetX() + ye.GetLocation().GetX()) / 2;
                            int y = (nd.GetLocation().GetY() + ye.GetLocation().GetY()) / 2;

                            using (g = Graphics.FromImage(bm))
                            {
                                graphics.DrawLine(pen, nd.getNodePoint(), ye.getNodePoint());
                                graphics.DrawString(con.length + " ", font, brush, new Point(x, y));
                                refreshNodes(graphics);
                                colorNode(nd);

                                if (isLetter)
                                    searchPath += ("-" + nd.getSName());
                                else
                                    searchPath += ("-" + nd.nodeIndex);
                                txtSearchPath.Text = searchPath;
                                await Task.Delay(1000);
                            }
                        }
                    }
                }
            }
        }

        private void updateAdjacencyMatrix(Node fromThisNode, Node toThisNode)
        {
            try
            {
                int fromIndex = tree.getNodes().IndexOf(fromThisNode);
                int toIndex = tree.getNodes().IndexOf(toThisNode);

                if (fromIndex >= 0 && toIndex >= 0 &&
                    fromIndex < adjacencyMatrix.Items.Count &&
                    toIndex + 1 < adjacencyMatrix.Items[fromIndex].SubItems.Count)
                {
                    adjacencyMatrix.Items[fromIndex].UseItemStyleForSubItems = false;
                    adjacencyMatrix.Items[fromIndex].SubItems[toIndex + 1].Text = "1";
                    adjacencyMatrix.Items[fromIndex].SubItems[toIndex + 1].ForeColor = Color.Crimson;

                    if (!chkboxDirected.Checked &&
                        toIndex < adjacencyMatrix.Items.Count &&
                        fromIndex + 1 < adjacencyMatrix.Items[toIndex].SubItems.Count)
                    {
                        adjacencyMatrix.Items[toIndex].UseItemStyleForSubItems = false;
                        adjacencyMatrix.Items[toIndex].SubItems[fromIndex + 1].Text = "1";
                        adjacencyMatrix.Items[toIndex].SubItems[fromIndex + 1].ForeColor = Color.Crimson;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating adjacency matrix: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void updateAdjacencyMatrixRemove(Node fromThisNode, Node toThisNode)
        {
            try
            {
                int fromIndex = tree.getNodes().IndexOf(fromThisNode);
                int toIndex = tree.getNodes().IndexOf(toThisNode);

                if (fromIndex >= 0 && toIndex >= 0 &&
                    fromIndex < adjacencyMatrix.Items.Count &&
                    toIndex + 1 < adjacencyMatrix.Items[fromIndex].SubItems.Count)
                {
                    adjacencyMatrix.Items[fromIndex].UseItemStyleForSubItems = false;
                    adjacencyMatrix.Items[fromIndex].SubItems[toIndex + 1].Text = "0";
                    adjacencyMatrix.Items[fromIndex].SubItems[toIndex + 1].ForeColor = Color.Black;

                    if (!chkboxDirected.Checked &&
                        toIndex < adjacencyMatrix.Items.Count &&
                        fromIndex + 1 < adjacencyMatrix.Items[toIndex].SubItems.Count)
                    {
                        adjacencyMatrix.Items[toIndex].UseItemStyleForSubItems = false;
                        adjacencyMatrix.Items[toIndex].SubItems[fromIndex + 1].Text = "0";
                        adjacencyMatrix.Items[toIndex].SubItems[fromIndex + 1].ForeColor = Color.Black;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating adjacency matrix: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Node getShortest(List<Node> list)
        {
            if (list == null || list.Count == 0) return null;

            Node r = list[0];
            foreach (Node v in list)
            {
                if (v.currentDistance < r.currentDistance)
                {
                    r = v;
                }
            }
            return r;
        }

        private void refreshNodes(Graphics graphics)
        {
            using (SolidBrush yellowBrush = new SolidBrush(Color.Yellow))
            {
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;

                foreach (Node v in tree.getNodes())
                {
                    Rectangle rect = new Rectangle(v.getNodePoint().X - (NODESIZE / 2), v.getNodePoint().Y - (NODESIZE / 2), NODESIZE, NODESIZE);
                    graphics.FillPie(yellowBrush, rect, 0, 360);

                    if (isLetter)
                        graphics.DrawString("" + v.getSName(), this.Font, Brushes.Black, rect, sf);
                    else
                        graphics.DrawString("" + v.getNodeNum(), this.Font, Brushes.Black, rect, sf);
                }
            }
        }

        private void cmbStartSPNode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbStartSPNode.SelectedItem == null) return;

            cmbEndSPNode.Items.Clear();
            foreach (Node nd in tree.getNodes())
            {
                if (isLetter)
                    cmbEndSPNode.Items.Add(nd.getSName());
                else
                    cmbEndSPNode.Items.Add(nd.getNodeNum().ToString());
            }

            // Remove the start node from end node options
            cmbEndSPNode.Items.Remove(cmbStartSPNode.SelectedItem);

            // Select first available end node
            if (cmbEndSPNode.Items.Count > 0)
                cmbEndSPNode.SelectedIndex = 0;

            // Update heuristic display when start node changes
            UpdateHeuristicDisplay();
        }

        private void exportGraphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveGraphDialog.ShowDialog();
        }

        private void saveGraphDialog_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(saveGraphDialog.FileName, false))
                {
                    foreach (Node node in tree.getNodes())
                    {
                        if (node == null) { break; }
                        if (isLetter)
                            writer.Write(node.getSName());
                        else
                            writer.Write(node.getNodeNum());

                        writer.Write(" " + node.GetLocation().GetX() + " " + node.GetLocation().GetY());
                        foreach (Node inNode in node.AdjacentList)
                        {
                            if (inNode == null) { break; }
                            if (isLetter)
                                writer.Write(" " + inNode.getSName());
                            else
                                writer.Write(" " + inNode.getNodeNum());
                        }
                        writer.WriteLine(" ");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving graph: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fromFile = true;
            openGraphDialog.ShowDialog();
        }

        private void openGraphDialog_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                using (StreamReader reader = new StreamReader(openGraphDialog.FileName))
                {
                    int lNumber;
                    String line;
                    Node temNode;
                    String[] nodeInfo = new String[23];
                    isLetter = true;

                    setDefault();
                    fromFile = true;

                    lNumber = 0;
                    line = reader.ReadLine();

                    while (line != null)
                    {
                        nodeInfo = line.Split(' ');

                        try
                        {
                            int.Parse(nodeInfo[0]);
                            isLetter = false;
                        }
                        catch (Exception)
                        {
                            isLetter = true;
                        }

                        if (isLetter)
                            temNode = new Node(int.Parse(nodeInfo[1]), int.Parse(nodeInfo[2]), getNodeNum(nodeInfo[0]));
                        else
                            temNode = new Node(int.Parse(nodeInfo[1]), int.Parse(nodeInfo[2]), int.Parse(nodeInfo[0]));

                        temNode.setNodeStatus("Add");
                        drawNode(temNode, temNode.getNodeStatus(), isLetter);
                        line = reader.ReadLine();
                        lNumber++;
                    }
                }

                using (StreamReader reader = new StreamReader(openGraphDialog.FileName))
                {
                    int lNumber = 0;
                    String line = reader.ReadLine();
                    while (line != null)
                    {
                        String[] nodeInfo = line.Split(' ');

                        for (int i = 3; i < nodeInfo.Length; i++)
                        {
                            if (nodeInfo[i].Length == 0) { break; }
                            if (isLetter)
                                disOrConnectNode(tree.getSpecificNode(lNumber), tree.getSpecificNode(tree.getNodeIndex(getNodeNum(nodeInfo[i]))), true);
                            else
                                disOrConnectNode(tree.getSpecificNode(lNumber), tree.getSpecificNode(tree.getNodeIndex(int.Parse(nodeInfo[i]))), true);
                        }

                        line = reader.ReadLine();
                        lNumber++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading graph: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool drawNode(Node node, String ns, bool isLetter)
        {
            using (SolidBrush yellowBrush = new SolidBrush(Color.Yellow))
            using (SolidBrush whiteBrush = new SolidBrush(Color.White))
            using (SolidBrush greenBrush = new SolidBrush(Color.Cyan))
            {
                Rectangle rect = new Rectangle(node.GetLocation().GetX() - (NODESIZE / 2),
                                             node.GetLocation().GetY() - (NODESIZE / 2),
                                             NODESIZE, NODESIZE);

                using (g = Graphics.FromImage(bm))
                {
                    if (ns.Equals("Add") || ns.Equals("Cancel"))
                    {
                        g.FillPie(yellowBrush, rect, 0, 360);
                        if (ns.Equals("Add") && tree.addNode(node))
                        {
                            if (isLetter)
                            {
                                g.DrawString("" + node.getSName(), this.Font, Brushes.Black, rect, sf);
                                adjacencyMatrix.addCell("" + node.getSName());
                                UpdateComboBoxes();
                            }
                            else
                            {
                                g.DrawString("" + node.getNodeNum(), this.Font, Brushes.Black, rect, sf);
                                adjacencyMatrix.addCell("" + node.getNodeNum());
                                UpdateComboBoxes();
                            }

                            if (cmbStartSPNode.Items.Count > 0)
                                cmbStartSPNode.SelectedIndex = 0;
                            if (cmbEndSPNode.Items.Count > 1)
                                cmbEndSPNode.SelectedIndex = 1;

                            // Update heuristic display when node is added
                            UpdateHeuristicDisplay();

                            graphingArea.Image = bm;
                            return true;
                        }
                        else if (ns.Equals("Cancel"))
                        {
                            if (isLetter)
                                g.DrawString("" + node.getSName(), this.Font, Brushes.Black, rect, sf);
                            else
                                g.DrawString("" + node.getNodeNum(), this.Font, Brushes.Black, rect, sf);

                            clickedNode = null;
                            clickNodeCount = 0;
                        }
                        else
                        {
                            return false;
                        }
                        graphingArea.Image = bm;
                        return true;
                    }
                    else if (ns.Equals("Delete"))
                    {
                        g.FillPie(whiteBrush, rect, 0, 360);

                        // Update comboboxes and heuristic display when node is deleted
                        UpdateComboBoxes();
                        UpdateHeuristicDisplay();

                        // Clear selections if they're now invalid
                        if (cmbStartSPNode.SelectedItem != null && !cmbStartSPNode.Items.Contains(cmbStartSPNode.SelectedItem))
                        {
                            if (cmbStartSPNode.Items.Count > 0)
                                cmbStartSPNode.SelectedIndex = 0;
                            else
                                cmbStartSPNode.SelectedItem = null;
                        }

                        if (cmbEndSPNode.SelectedItem != null && !cmbEndSPNode.Items.Contains(cmbEndSPNode.SelectedItem))
                        {
                            if (cmbEndSPNode.Items.Count > 0)
                                cmbEndSPNode.SelectedIndex = 0;
                            else
                                cmbEndSPNode.SelectedItem = null;
                        }

                        graphingArea.Image = bm;
                        return true;
                    }
                    else if (ns.Equals("Selected"))
                    {
                        g.FillPie(greenBrush, rect, 0, 360);
                        if (isLetter)
                            g.DrawString("" + node.getSName(), this.Font, Brushes.Black, rect, sf);
                        else
                            g.DrawString("" + node.getNodeNum(), this.Font, Brushes.Black, rect, sf);

                        graphingArea.Image = bm;
                    }
                }
                return false;
            }
        }

        public int getNodeNum(String nodeName)
        {
            int nx;
            for (nx = 0; nx < sName.Length; nx++)
            {
                if (this.sName.Substring(nx, 1).Equals(nodeName))
                {
                    break;
                }
            }
            return nx;
        }

        private void rbNum_Click(object sender, EventArgs e)
        {
            isLetter = false;
            // Update comboboxes when label type changes
            UpdateComboBoxes();
            UpdateHeuristicDisplay();
        }

        private void rbLetter_Click(object sender, EventArgs e)
        {
            isLetter = true;
            // Update comboboxes when label type changes
            UpdateComboBoxes();
            UpdateHeuristicDisplay();
        }

        private void UpdateComboBoxes()
        {
            cmbStartSPNode.Items.Clear();
            cmbEndSPNode.Items.Clear();

            foreach (Node nd in tree.getNodes())
            {
                if (isLetter)
                {
                    cmbStartSPNode.Items.Add(nd.getSName());
                    cmbEndSPNode.Items.Add(nd.getSName());
                }
                else
                {
                    cmbStartSPNode.Items.Add(nd.getNodeNum().ToString());
                    cmbEndSPNode.Items.Add(nd.getNodeNum().ToString());
                }
            }

            if (cmbStartSPNode.Items.Count > 0)
                cmbStartSPNode.SelectedIndex = 0;
            if (cmbEndSPNode.Items.Count > 1)
                cmbEndSPNode.SelectedIndex = 1;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setDefault();
            UpdateHeuristicDisplay();
        }

        private void ClearSearch()
        {
            txtSearchPath.Clear();
            searchPath = "";
            graphingArea.Refresh();
        }

        private async void rbDFS_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDFS.Checked)
            {
                if (tree.getNodes().Count == 0)
                {
                    MessageBox.Show("Add nodes first then connect", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    rbDFS.Checked = false;
                    return;
                }
                ClearSearch();
                await depthFirstSearch();
                rbDFS.Checked = false;
            }
        }

        private async Task depthFirstSearch()
        {
            txtSearchPath.Clear();
            startingNode2();

            if (sNode == null)
            {
                MessageBox.Show("Please select a valid start node.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (isLetter)
                searchPath += ("" + sNode.getSName());
            else
                searchPath += ("" + sNode.nodeIndex);

            foreach (Node inNode in tree.getNodes())
            {
                inNode.visited = 0;
            }

            bool exit = false;
            i = 2;

            while (!exit)
            {
                foreach (Node inNode in tree.getNodes())
                {
                    if (inNode == sNode && inNode.visited == 0)
                    {
                        colorNode(inNode);
                        await Task.Delay(1000);
                        await DFS(inNode);
                    }
                }

                if (i > tree.getNodes().Count)
                {
                    exit = true;
                }
            }
            MessageBox.Show("Depth First Search Completed!");
        }

        private async void rbBFS_CheckedChanged(object sender, EventArgs e)
        {
            if (rbBFS.Checked)
            {
                if (tree.getNodes().Count == 0)
                {
                    MessageBox.Show("Add nodes first then connect", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    rbBFS.Checked = false;
                    return;
                }

                ClearSearch();
                await breadthFirstSearch();
                rbBFS.Checked = false;
            }
        }

        private async Task breadthFirstSearch()
        {
            txtSearchPath.Clear();
            startingNode2();

            if (sNode == null)
            {
                MessageBox.Show("Please select a valid start node.", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (isLetter)
                searchPath += ("" + sNode.getSName());
            else
                searchPath += ("" + sNode.nodeIndex);

            foreach (Node inNode in tree.getNodes())
                inNode.visited = 0;

            i = 2;
            colorNode(sNode);
            await Task.Delay(1000);

            await BFS(sNode, endNode);
            MessageBox.Show("Breadth First Search Completed!");
        }

        private void getHeuristic(Node end)
        {
            listBox1.Items.Clear();

            foreach (Node n in tree.getNodes())
            {
                if (n == end)
                {
                    n.HeuristicValue = 0;
                }
                else
                {
                    n.HeuristicValue = n.distanceTo(end.getNodePoint());
                }

                if (isLetter)
                    listBox1.Items.Add(n.getSName() + "   " + n.HeuristicValue);
                else
                    listBox1.Items.Add(n.getNodeNum() + "   " + n.HeuristicValue);
            }

            listBox1.Refresh();
        }

        private async Task drawEdge(Node start, Node nodeCur)
        {
            using (Graphics graphics = graphingArea.CreateGraphics())
            using (Pen pen = new Pen(Color.Blue, 3))
            {
                String txtpath = "";

                if (isLetter)
                    txtpath = " " + nodeCur.getSName();
                else
                    txtpath = " " + nodeCur.nodeIndex;

                while (nodeCur != start && nodeCur != null && nodeCur.predecessor != null)
                {
                    using (g = Graphics.FromImage(bm))
                    {
                        await DrawLine(nodeCur.predecessor, nodeCur);
                    }
                    nodeCur = nodeCur.predecessor;
                    if (isLetter)
                        txtpath = "-" + nodeCur.getSName() + txtpath;
                    else
                        txtpath = "-" + nodeCur.nodeIndex + txtpath;
                }
                colorNode(start);
                txtSearchPath.Text = txtpath;
            }
        }

        private async Task DrawLine(Node vFrom, Node vTo)
        {
            using (Graphics graphics = graphingArea.CreateGraphics())
            using (Pen pen = new Pen(Color.White, 7)) //blue
            {
                graphics.DrawLine(pen, vFrom.getNodePoint(), vTo.getNodePoint());
                searchPath += "->" + vTo.getNodeNum();
                colorNode(vTo);
                await Task.Delay(1000);
                refreshNodes(graphics);
            }
        }

        private void colorNode(Node node)
        {
            using (SolidBrush redBrush = new SolidBrush(Color.Blue))
            using (Graphics graphics = graphingArea.CreateGraphics())
            {
                Rectangle rect = new Rectangle(node.getNodePoint().X - (NODESIZE / 2),
                                             node.getNodePoint().Y - (NODESIZE / 2),
                                             NODESIZE, NODESIZE);
                graphics.FillPie(redBrush, rect, 0, 360);

                if (isLetter)
                    graphics.DrawString("" + node.getSName(), this.Font, Brushes.White, rect, sf);
                else
                    graphics.DrawString("" + node.getNodeNum(), this.Font, Brushes.White, rect, sf);
            }
        }

        private void getStartAndEndNode()
        {
            if (cmbStartSPNode.SelectedItem == null || cmbEndSPNode.SelectedItem == null)
            {
                MessageBox.Show("Please select both start and end nodes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sNode = null;
                endNode = null;
                return;
            }

            if (isLetter)
            {
                string startName = cmbStartSPNode.SelectedItem.ToString();
                string endName = cmbEndSPNode.SelectedItem.ToString();

                foreach (Node n in tree.getNodes())
                {
                    if (n.getSName().Equals(startName))
                    {
                        sNode = n;
                    }
                    if (n.getSName().Equals(endName))
                    {
                        endNode = n;
                    }
                }
            }
            else
            {
                try
                {
                    int startIndex = int.Parse(cmbStartSPNode.SelectedItem.ToString());
                    int endIndex = int.Parse(cmbEndSPNode.SelectedItem.ToString());

                    foreach (Node n in tree.getNodes())
                    {
                        if (n.getNodeNum() == startIndex)
                        {
                            sNode = n;
                        }
                        if (n.getNodeNum() == endIndex)
                        {
                            endNode = n;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error parsing node indices: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    sNode = null;
                    endNode = null;
                }
            }
        }

        private void chkboxDirected_CheckedChanged(object sender, EventArgs e)
        {
            checkedDir = chkboxDirected.Checked;
        }

        private bool isProcessingAStar = false; // class-level variable

        private async void rbAStar_CheckedChanged(object sender, EventArgs e)
        {
            // Prevent re-entrancy
            if (isProcessingAStar) return;

            if (rbAStar.Checked)
            {
                isProcessingAStar = true;

                try
                {
                    if (tree.getNodes().Count == 0)
                    {
                        MessageBox.Show("Add nodes first then connect", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        rbAStar.Checked = false;
                        return;
                    }

                    ClearSearch();
                    getStartAndEndNode();

                    if (sNode == null || endNode == null)
                    {
                        rbAStar.Checked = false;
                        return;
                    }

                    // Reset all nodes for A* search
                    foreach (Node node in tree.getNodes())
                    {
                        node.visited = 0;
                        node.Cost = int.MaxValue;
                        node.currentDistance = int.MaxValue;
                        node.predecessor = null;
                        node.HeuristicValue = 0;
                        node.Fn = 0;
                    }

                    // Calculate heuristic values
                    foreach (Node n in tree.getNodes())
                    {
                        n.HeuristicValue = n.distanceTo(endNode.getNodePoint());
                    }

                    UpdateHeuristicList(endNode);

                    sNode.Cost = 0;
                    sNode.currentDistance = sNode.Cost + sNode.HeuristicValue;

                    List<Node> openList = new List<Node> { sNode };
                    List<Node> closedList = new List<Node>();

                    colorNode(sNode);
                    await Task.Delay(500);

                    bool foundPath = false;

                    while (openList.Count > 0 && !foundPath)
                    {
                        Node currentNode = openList[0];
                        int minFScore = currentNode.currentDistance;
                        int minIndex = 0;

                        for (int i = 1; i < openList.Count; i++)
                        {
                            if (openList[i].currentDistance < minFScore)
                            {
                                currentNode = openList[i];
                                minFScore = currentNode.currentDistance;
                                minIndex = i;
                            }
                        }

                        openList.RemoveAt(minIndex);
                        closedList.Add(currentNode);

                        colorNode(currentNode);
                        await Task.Delay(200);

                        if (currentNode == endNode)
                        {
                            await ReconstructAndDrawPath(sNode, currentNode);
                            txtSearchPath.Text = GetShortestPathText(sNode, currentNode);
                            foundPath = true;
                            break;
                        }

                        foreach (Node neighbor in currentNode.AdjacentList)
                        {
                            if (closedList.Contains(neighbor))
                                continue;

                            Edge connectingEdge = null;
                            foreach (Edge ed in edgesDict.Values)
                            {
                                if (ed.nodeFrom == currentNode && ed.nodeTo == neighbor)
                                {
                                    connectingEdge = ed;
                                    break;
                                }
                            }

                            if (connectingEdge == null) continue;

                            int tentativeGScore = currentNode.Cost + connectingEdge.length;
                            bool isBetterPath = false;

                            if (!openList.Contains(neighbor))
                            {
                                openList.Add(neighbor);
                                isBetterPath = true;
                            }
                            else if (tentativeGScore < neighbor.Cost)
                            {
                                isBetterPath = true;
                            }

                            if (isBetterPath)
                            {
                                neighbor.predecessor = currentNode;
                                neighbor.Cost = tentativeGScore;
                                neighbor.currentDistance = neighbor.Cost + neighbor.HeuristicValue;

                                colorNode(neighbor);
                                await Task.Delay(150);
                            }
                        }
                    }

                    if (foundPath)
                    {
                        MessageBox.Show("A* Search Completed!");
                    }
                    else
                    {
                        MessageBox.Show("No path found using A*!");
                    }
                }
                finally
                {
                    isProcessingAStar = false;
                    rbAStar.Checked = false;
                }
            }
        }

        // Helper method to update heuristic list display
        private void UpdateHeuristicList(Node end)
        {
            listBox1.Items.Clear();

            foreach (Node n in tree.getNodes())
            {
                if (isLetter)
                    listBox1.Items.Add(n.getSName() + "   " + n.HeuristicValue);
                else
                    listBox1.Items.Add(n.getNodeNum() + "   " + n.HeuristicValue);
            }

            listBox1.Refresh();
        }

        // NEW METHOD: Update heuristic display based on selected end node
        private void UpdateHeuristicDisplay()
        {
            if (tree.getNodes().Count == 0)
            {
                listBox1.Items.Clear();
                return;
            }

            // Get the currently selected end node for heuristic calculation
            Node referenceNode = null;

            if (cmbEndSPNode.SelectedItem != null)
            {
                string endName = cmbEndSPNode.SelectedItem.ToString();
                foreach (Node n in tree.getNodes())
                {
                    if ((isLetter && n.getSName().Equals(endName)) ||
                        (!isLetter && n.getNodeNum().ToString().Equals(endName)))
                    {
                        referenceNode = n;
                        break;
                    }
                }
            }

            // If no end node selected, use the first node as reference
            if (referenceNode == null && tree.getNodes().Count > 0)
            {
                referenceNode = tree.getNodes().First();
            }

            // Update heuristic values
            if (referenceNode != null)
            {
                getHeuristic(referenceNode);
            }
        }

        private string GetShortestPathText(Node start, Node end)
        {
            if (start == null || end == null) return "";

            StringBuilder pathText = new StringBuilder();
            List<Node> path = new List<Node>();
            Node current = end;

            // Reconstruct path
            while (current != null && current != start)
            {
                path.Insert(0, current);
                current = current.predecessor;
            }

            if (current == start)
            {
                path.Insert(0, start);
            }

            // Build text representation
            for (int i = 0; i < path.Count; i++)
            {
                if (i > 0) pathText.Append("-");

                if (isLetter)
                    pathText.Append(path[i].getSName());
                else
                    pathText.Append(path[i].nodeIndex);
            }

            return pathText.ToString();
        }

        private void startingNode2()
        {
            if (cmbStartSPNode.SelectedItem == null)
            {
                MessageBox.Show("Please select a start node.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sNode = null;
                return;
            }

            if (isLetter)
            {
                string startName = cmbStartSPNode.SelectedItem.ToString();
                foreach (Node n in tree.getNodes())
                {
                    if (n.getSName().Equals(startName))
                    {
                        sNode = n;
                        break;
                    }
                }
            }
            else
            {
                try
                {
                    int startIndex = int.Parse(cmbStartSPNode.SelectedItem.ToString());
                    foreach (Node n in tree.getNodes())
                    {
                        if (n.getNodeNum() == startIndex)
                        {
                            sNode = n;
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error parsing start node index: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    sNode = null;
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private DataGridView dgvHeuristic;

        private void InitializeDataGridView()
        {
            dgvHeuristic = new DataGridView();
            dgvHeuristic.Name = "dataGridViewHeuristic";
            dgvHeuristic.Location = new Point(10, 100);
            dgvHeuristic.Size = new Size(300, 200);
            dgvHeuristic.AllowUserToAddRows = false;
            dgvHeuristic.AllowUserToDeleteRows = false;
            dgvHeuristic.ReadOnly = true;

            dgvHeuristic.Columns.Add("Node", "Node");
            dgvHeuristic.Columns.Add("HeuristicValue", "Heuristic Value");

            this.Controls.Add(dgvHeuristic);
            dgvHeuristic.Visible = false;
        }

        // FIXED ReconstructAndDrawPath method
        private async Task ReconstructAndDrawPath(Node start, Node end)
        {
            if (end == null || start == null) return;

            List<Node> path = new List<Node>();
            Node current = end;

            // Reconstruct path from end to start
            while (current != null && current != start)
            {
                path.Insert(0, current);
                current = current.predecessor;
            }

            if (current == start)
            {
                path.Insert(0, start);
            }

            // Draw the path
            if (path.Count > 1)
            {
                for (int i = 0; i < path.Count - 1; i++)
                {
                    await DrawLine(path[i], path[i + 1]);
                    await Task.Delay(500);
                }
            }
        }

        // FIXED EVENT HANDLERS - Now all use CheckedChanged
        private void cmbEndSPNode_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Update heuristic display when end node changes
            UpdateHeuristicDisplay();
        }

        private async void rbDijkstra_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDijkstra.Checked)
            {
                if (tree.getNodes().Count == 0)
                {
                    MessageBox.Show("Please add nodes first!");
                    rbDijkstra.Checked = false;
                    return;
                }

                ClearSearch();
                getStartAndEndNode();

                if (sNode == null || endNode == null)
                {
                    rbDijkstra.Checked = false;
                    return;
                }

                // Initialize all nodes
                foreach (Node nd in tree.getNodes())
                {
                    nd.Cost = int.MaxValue;  // Distance from start
                    nd.predecessor = null;
                    nd.visited = 0;
                    nd.currentDistance = int.MaxValue;
                }

                // Start node distance = 0
                sNode.Cost = 0;
                sNode.currentDistance = 0;

                // Create list of unvisited nodes
                List<Node> unvisited = new List<Node>(tree.getNodes());

                // For visualization
                colorNode(sNode);
                await Task.Delay(300);

                while (unvisited.Count > 0)
                {
                    // Find unvisited node with smallest distance
                    Node currentNode = unvisited[0];
                    int minDistance = currentNode.Cost;
                    int minIndex = 0;

                    for (int i = 1; i < unvisited.Count; i++)
                    {
                        if (unvisited[i].Cost < minDistance)
                        {
                            currentNode = unvisited[i];
                            minDistance = currentNode.Cost;
                            minIndex = i;
                        }
                    }

                    // Remove current node from unvisited
                    unvisited.RemoveAt(minIndex);

                    // Mark as visited
                    currentNode.visited = 1;

                    // If we reached the goal
                    if (currentNode == endNode)
                    {
                        await ReconstructAndDrawPath(sNode, endNode);
                        txtSearchPath.Text = GetShortestPathText(sNode, endNode);
                        MessageBox.Show("Dijkstra's Algorithm Completed!");
                        rbDijkstra.Checked = false;
                        return;
                    }

                    // Update distances to neighbors
                    foreach (Node neighbor in currentNode.AdjacentList)
                    {
                        // Skip if already visited
                        if (neighbor.visited == 1)
                            continue;

                        // Find the edge connecting currentNode to neighbor
                        Edge connectingEdge = null;
                        foreach (Edge ed in edgesDict.Values)
                        {
                            if (ed.nodeFrom == currentNode && ed.nodeTo == neighbor)
                            {
                                connectingEdge = ed;
                                break;
                            }
                        }

                        if (connectingEdge == null) continue;

                        // Calculate alternative distance
                        int altDistance = currentNode.Cost + connectingEdge.length;

                        // If we found a shorter path to neighbor
                        if (altDistance < neighbor.Cost)
                        {
                            neighbor.Cost = altDistance;
                            neighbor.predecessor = currentNode;
                            neighbor.currentDistance = altDistance;

                            // Visualize
                            colorNode(neighbor);
                            await Task.Delay(200); // 200
                        }
                    }
                }

                MessageBox.Show("No path found using Dijkstra!");
                rbDijkstra.Checked = false;
            }
        }

        private async void rbUniformCost_CheckedChanged(object sender, EventArgs e)
        {
            if (rbUniformCost.Checked)
            {
                if (tree.getNodes().Count == 0)
                {
                    MessageBox.Show("Please add nodes first.");
                    rbUniformCost.Checked = false;
                    return;
                }

                ClearSearch();
                using (Graphics graphics = graphingArea.CreateGraphics())
                using (Pen pen = new Pen(Color.White, 7))
                using (Font font = new Font(FontFamily.GenericSansSerif, 8))
                using (SolidBrush brush = new SolidBrush(Color.Black))

                    getStartAndEndNode();

                if (sNode == null || endNode == null)
                {
                    rbUniformCost.Checked = false;
                    return;
                }

                // Initialize all nodes
                foreach (Node node in tree.getNodes())
                {
                    node.visited = 0;
                    node.Cost = int.MaxValue;  // g(n) - cost from start
                    node.predecessor = null;
                    node.currentDistance = int.MaxValue;
                }

                // Priority queue simulation using list
                List<Node> openList = new List<Node>();
                sNode.Cost = 0;
                sNode.currentDistance = 0;
                openList.Add(sNode);

                // For visualization
                colorNode(sNode);
                await Task.Delay(300);

                while (openList.Count > 0)
                {
                    // Get node with lowest cost
                    Node currentNode = openList[0];
                    int minCost = currentNode.Cost;
                    int minIndex = 0;

                    for (int i = 1; i < openList.Count; i++)
                    {
                        if (openList[i].Cost < minCost)
                        {
                            currentNode = openList[i];
                            minCost = currentNode.Cost;
                            minIndex = i;
                        }
                    }

                    // Remove current node from open list
                    openList.RemoveAt(minIndex);

                    // Mark as visited
                    currentNode.visited = 1;

                    // If we reached the goal
                    if (currentNode == endNode)
                    {
                        await ReconstructAndDrawPath(sNode, currentNode);
                        txtSearchPath.Text = GetShortestPathText(sNode, currentNode);
                        MessageBox.Show("Uniform Cost Search Completed!");
                        rbUniformCost.Checked = false;
                        return;
                    }

                    // Check all neighbors
                    foreach (Node neighbor in currentNode.AdjacentList)
                    {
                        // Skip if already visited
                        if (neighbor.visited == 1)
                            continue;

                        // Find the edge connecting currentNode to neighbor
                        Edge connectingEdge = null;
                        foreach (Edge ed in edgesDict.Values)
                        {
                            if (ed.nodeFrom == currentNode && ed.nodeTo == neighbor)
                            {
                                connectingEdge = ed;
                                break;
                            }
                        }

                        if (connectingEdge == null) continue;

                        // Calculate new cost = current cost + edge weight
                        int newCost = currentNode.Cost + connectingEdge.length;

                        // If we found a better path to neighbor
                        if (newCost < neighbor.Cost)
                        {
                            neighbor.Cost = newCost;
                            neighbor.predecessor = currentNode;
                            neighbor.currentDistance = newCost;

                            // Add to open list if not already there
                            if (!openList.Contains(neighbor))
                            {
                                openList.Add(neighbor);
                            }

                            // Visualize
                            colorNode(neighbor);
                            await Task.Delay(200);
                        }
                    }
                }

                MessageBox.Show("No path found using Uniform Cost!");
                rbUniformCost.Checked = false;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e) { }

        private void label14_Click(object sender, EventArgs e) { }

        private void frmTreeTraversal_Load(object sender, EventArgs e)
        {
            // Make heuristic display visible by default
            label10.Visible = true;
            listBox1.Visible = true;
            UpdateHeuristicDisplay();
        }

        private async void rbKruskal_CheckedChanged(object sender, EventArgs e)
        {
            if (rbKruskal.Checked)
            {
                if (tree.getNodes().Count == 0)
                {
                    MessageBox.Show("Please add nodes first");
                    rbKruskal.Checked = false;
                    return;
                }

                ClearSearch();

                using (Graphics graphics = graphingArea.CreateGraphics())
                using (Pen pen = new Pen(Color.White, 7))
                using (Font font = new Font(FontFamily.GenericSansSerif, 8))
                using (SolidBrush brush = new SolidBrush(Color.Black))
                {
                    List<Edge> allEdges = edgesDict.Values.ToList();
                    allEdges.Sort(Edge.SortEdgesByLength);

                    Dictionary<Node, Node> parent = new Dictionary<Node, Node>();
                    foreach (Node n in tree.getNodes())
                        parent[n] = n;

                    Node Find(Node n)
                    {
                        if (parent[n] != n)
                            parent[n] = Find(parent[n]);
                        return parent[n];
                    }

                    void Union(Node a, Node b)
                    {
                        a = Find(a);
                        b = Find(b);
                        if (a != b)
                            parent[b] = a;
                    }

                    List<Edge> mstEdges = new List<Edge>();

                    foreach (Edge edge in allEdges)
                    {
                        Node rootA = Find(edge.nodeFrom);
                        Node rootB = Find(edge.nodeTo);

                        if (rootA != rootB)
                        {
                            mstEdges.Add(edge);
                            Union(edge.nodeFrom, edge.nodeTo);

                            int midX = (edge.nodeFrom.GetLocation().GetX() + edge.nodeTo.GetLocation().GetX()) / 2;
                            int midY = (edge.nodeFrom.GetLocation().GetY() + edge.nodeTo.GetLocation().GetY()) / 2;

                            using (g = Graphics.FromImage(bm))
                            {
                                graphics.DrawLine(pen, edge.nodeFrom.getNodePoint(), edge.nodeTo.getNodePoint());
                                graphics.DrawString(edge.length + " ", font, brush, new Point(midX, midY));
                                refreshNodes(graphics);

                                colorNode(edge.nodeFrom);
                                colorNode(edge.nodeTo);

                                if (isLetter)
                                    searchPath += "-" + edge.nodeTo.getSName();
                                else
                                    searchPath += "-" + edge.nodeTo.nodeIndex;

                                txtSearchPath.Text = searchPath;
                            }

                            await Task.Delay(800);
                        }

                        if (mstEdges.Count == tree.getNodes().Count - 1)
                            break;
                    }

                    MessageBox.Show("Kruskal Algorithm completed!");
                    rbKruskal.Checked = false;
                }
            }
        }

        private async void rbPrims_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPrims.Checked)
            {
                if (tree.getNodes().Count == 0)
                {
                    MessageBox.Show("Please add nodes first");
                    rbPrims.Checked = false;
                    return;
                }

                ClearSearch();

                List<Node> visited = new List<Node>();
                List<Edge> mstEdges = new List<Edge>();

                using (Graphics graphics = graphingArea.CreateGraphics())
                using (Pen pen = new Pen(Color.White, 7))
                using (Font font = new Font(FontFamily.GenericSansSerif, 8))
                using (SolidBrush brush = new SolidBrush(Color.Black))
                {
                    Node startNode = tree.getNodes().First();
                    visited.Add(startNode);
                    colorNode(startNode);
                    await Task.Delay(1000);

                    while (visited.Count < tree.getNodes().Count)
                    {
                        List<Edge> candidateEdges = new List<Edge>();

                        foreach (Node fromNode in visited)
                        {
                            foreach (Node toNode in fromNode.AdjacentList)
                            {
                                if (!visited.Contains(toNode))
                                {
                                    foreach (Edge ed in edgesDict.Values)
                                    {
                                        if (ed.nodeFrom == fromNode && ed.nodeTo == toNode)
                                        {
                                            candidateEdges.Add(ed);
                                        }
                                    }
                                }
                            }
                        }

                        if (candidateEdges.Count == 0) break;

                        candidateEdges.Sort(Edge.SortEdgesByLength);
                        Edge minEdge = candidateEdges.First();

                        mstEdges.Add(minEdge);
                        visited.Add(minEdge.nodeTo);

                        int x = (minEdge.nodeFrom.GetLocation().GetX() + minEdge.nodeTo.GetLocation().GetX()) / 2;
                        int y = (minEdge.nodeFrom.GetLocation().GetY() + minEdge.nodeTo.GetLocation().GetY()) / 2;

                        using (g = Graphics.FromImage(bm))
                        {
                            graphics.DrawLine(pen, minEdge.nodeFrom.getNodePoint(), minEdge.nodeTo.getNodePoint());
                            graphics.DrawString(minEdge.length + " ", font, brush, new Point(x, y));
                            refreshNodes(graphics);
                            colorNode(minEdge.nodeTo);

                            if (isLetter)
                                searchPath += ("-" + minEdge.nodeTo.getSName());
                            else
                                searchPath += ("-" + minEdge.nodeTo.nodeIndex);

                            txtSearchPath.Text = searchPath;
                            await Task.Delay(500);
                        }
                    }

                    MessageBox.Show("Prims Algorithm completed!");
                    rbPrims.Checked = false;
                }
            }
        }
    }
}