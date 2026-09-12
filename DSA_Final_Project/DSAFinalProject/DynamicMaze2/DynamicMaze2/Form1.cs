using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DynamicMaze2
{
    public partial class Form1 : Form
    {
        private int Xmin, Ymin, CellWid, CellHgt;
        Bitmap bm;
        MazeNode[,] nodes;
        private List<MazeNode> dfsPath;
        private MazeNode currentPosition;
        private MazeNode previousPosition;
        private List<MazeNode> currentPath = new List<MazeNode>();
        private List<MazeNode> visitedNodes = new List<MazeNode>();

        public Form1()
        {
            InitializeComponent();
            bm = new Bitmap(mazeArea.ClientSize.Width, mazeArea.ClientSize.Height);

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                // Clear the visited nodes list.
                visitedNodes.Clear();

                int wid = int.Parse(txtWidth.Text);
                int hgt = int.Parse(txtHeight.Text);

                if (hgt <= 0 && wid <= 0)
                {
                    MessageBox.Show("Error: Invalid input, Both inputs must be greater than zero!", "Error: Invalid Rows and Columns", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (wid <= 0 )
                {
                    MessageBox.Show("Error: Invalid input, column must be greater than zero!", "Error: Invalid Column", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (hgt<= 0)
                {
                    MessageBox.Show("Error: Invalid input, row must be greater than zero!", "Error: Invalid Row", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
   


                CellWid = mazeArea.ClientSize.Width / (wid + 2);
                CellHgt = mazeArea.ClientSize.Height / (hgt + 2);
                if (CellWid > CellHgt) CellWid = CellHgt;
                else CellHgt = CellWid;
                Xmin = (mazeArea.ClientSize.Width - wid * CellWid) / 2;
                Ymin = (mazeArea.ClientSize.Height - hgt * CellHgt) / 2;

                nodes = MakeNodes(wid, hgt);

                // Build the spanning tree.
                FindSpanningTree(nodes[0, 0]);

                // Display the maze.
                DisplayMaze(nodes);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Please input Rows & Columns first!", "Error: Fillout fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private MazeNode[,] MakeNodes(int wid, int hgt)
        {
            // Make the nodes.
            MazeNode[,] nodes = new MazeNode[hgt, wid];
            for (int r = 0; r < hgt; r++)
            {
                int y = Ymin + CellHgt * r;
                for (int c = 0; c < wid; c++)
                {
                    int x = Xmin + CellWid * c;
                    nodes[r, c] = new MazeNode(
                        x, y, CellWid, CellHgt);
                }
            }

            // Initialize the nodes neighbors.
            for (int r = 0; r < hgt; r++)
            {
                for (int c = 0; c < wid; c++)
                {
                    if (r > 0)
                        nodes[r, c].Neighbors[MazeNode.North] = nodes[r - 1, c];
                    if (r < hgt - 1)
                        nodes[r, c].Neighbors[MazeNode.South] = nodes[r + 1, c];
                    if (c > 0)
                        nodes[r, c].Neighbors[MazeNode.West] = nodes[r, c - 1];
                    if (c < wid - 1)
                        nodes[r, c].Neighbors[MazeNode.East] = nodes[r, c + 1];
                }
            }

            // Return the nodes.
            return nodes;
        }

        private void DisplayMaze(MazeNode[,] nodes)
        {
            int hgt = nodes.GetUpperBound(0) + 1;
            int wid = nodes.GetUpperBound(1) + 1;
            Bitmap bm = new Bitmap(
                mazeArea.ClientSize.Width,
                mazeArea.ClientSize.Height);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                // gr.SmoothingMode = gr.SmoothingMode.AntiAlias;
                for (int r = 0; r < hgt; r++)
                {
                    for (int c = 0; c < wid; c++)
                    {
                         nodes[r, c].DrawCenter(gr, Brushes.Red);
                   nodes[r, c].DrawWalls(gr, Pens.Black);  //not commented
                        nodes[r, c].DrawNeighborLinks(gr, Pens.Black); //black
                        nodes[r, c].DrawBoundingBox(gr, Pens.Blue);
                        nodes[r, c].DrawPredecessorLink(gr, Pens.LightGray); //light gray
                    }
                }
            }

            mazeArea.Image = bm;
        }

        private void FindSpanningTree(MazeNode root)
        {
            Random rand = new Random();

            // Set the root node's predecessor so we know it's in the tree.
            root.Predecessor = root;

            // Make a list of candidate links.
            List<MazeLink> links = new List<MazeLink>();

            // Add the root's links to the links list.
            foreach (MazeNode neighbor in root.Neighbors)
            {
                if (neighbor != null)
                    links.Add(new MazeLink(root, neighbor));
            }

            // Add the other nodes to the tree.
            while (links.Count > 0)
            {
                // Pick a random link.
                int link_num = rand.Next(0, links.Count);
                MazeLink link = links[link_num];
                links.RemoveAt(link_num);

                // Add this link to the tree.
                MazeNode to_node = link.ToNode;
                link.ToNode.Predecessor = link.FromNode;

                // Remove any links from the list that point
                // to nodes that are already in the tree.
                // (That will be the newly added node.)
                for (int i = links.Count - 1; i >= 0; i--)
                {
                    if (links[i].ToNode.Predecessor != null)
                        links.RemoveAt(i);
                }

                // Add to_node's links to the links list.
                foreach (MazeNode neighbor in to_node.Neighbors)
                {
                    if ((neighbor != null) && (neighbor.Predecessor == null))
                        links.Add(new MazeLink(to_node, neighbor));
                }
            }
        }


        private void ResetVisitedProperty(MazeNode[,] nodes)
        {
            foreach (var node in nodes)
            {
                node.visited = 0;
            }
        }



        private List<int> GetRandomNeighborIndices()
        {
            List<int> indices = new List<int> { MazeNode.North, MazeNode.South, MazeNode.East, MazeNode.West };
            Random rand = new Random();
            int n = indices.Count;

            while (n > 1)
            {
                n--;
                int k = rand.Next(n + 1);
                int value = indices[k];
                indices[k] = indices[n];
                indices[n] = value;
            }
            return indices;
        }


        private void btnBFS_Click(object sender, EventArgs e)
        {
            visitedNodes.Clear();
            MazeNode startNode = nodes[0, 0];
            MazeNode finishNode = nodes[nodes.GetLength(0) - 1, nodes.GetLength(1) - 1];

            // Start the BFS traversal from the start node.
            BreadthFirstSearch(startNode, finishNode);
            System.Threading.Thread.Sleep(500);
        }



        private void DepthFirstSearch(MazeNode startNode, MazeNode finishNode)
        {
            // Reset everything
            visitedNodes.Clear();
            ResetVisitedProperty(nodes);

            Stack<MazeNode> stack = new Stack<MazeNode>();
            Dictionary<MazeNode, MazeNode> parentMap = new Dictionary<MazeNode, MazeNode>();
          
            currentPosition = startNode;
            previousPosition = null;

            stack.Push(startNode);

            while (stack.Count > 0)
            {
                MazeNode currentNode = stack.Pop();

                // If already visited, skip
                if (currentNode.visited == 1)
                    continue;

                currentNode.visited = 1;
                visitedNodes.Add(currentNode);

                previousPosition = currentPosition;
                currentPosition = currentNode;

                // Draw current state
                DrawPathInMaze(currentNode);
                System.Threading.Thread.Sleep(400);

                // Check if we reached target
                if (currentNode == finishNode)
                {
                    currentPosition = finishNode;
                    DrawPathInMaze(currentPosition);
                    MessageBox.Show("You've Reached the Goal Node using DFS!");
                    return;
                }

                // Process neighbors in order
                //int[] order = new int[] { MazeNode.North, MazeNode.South, MazeNode.East, MazeNode.West };

                int[] order = new int[] { MazeNode.North, MazeNode.East, MazeNode.South, MazeNode.West };

                foreach (int direction in order)
                {
                    MazeNode neighbor = currentNode.Neighbors[direction];

                    if (neighbor != null && neighbor.visited == 0)
                    {
                        // Only move if the wall is OPEN
                        if (!HasActiveWall(currentNode, neighbor))
                        {
                            stack.Push(neighbor);
                            parentMap[neighbor] = currentNode;
                        }
                    }
                }
                
            }
        }


        private void BreadthFirstSearch(MazeNode startNode, MazeNode finishNode)
        {
            Queue<MazeNode> queue = new Queue<MazeNode>();
            Dictionary<MazeNode, MazeNode> parentMap = new Dictionary<MazeNode, MazeNode>();

            // Reset the visited property of all nodes.
            ResetVisitedProperty(nodes);

            // Initialize the current position to the start node.   
            currentPosition = startNode;
            previousPosition = null;

            queue.Enqueue(startNode);

            while (queue.Count > 0)
            {
                MazeNode currentNode = queue.Dequeue();

                // Check if we have reached the finish node.
                if (currentNode == finishNode)
                {
                    currentPosition = finishNode; // Update the current position to the finish node.
                    DrawPathInMaze(currentPosition);
                    MessageBox.Show("You've Reached the Goal Node using BFS!");

                    break; // Path found.
                }

                // Mark the current node as visited.
                currentNode.visited = 1;

                // Update the previous position to the current position.
                previousPosition = currentPosition;

                // Update the current position.
                currentPosition = currentNode;
                visitedNodes.Add(currentNode);
                // Draw the path in the maze with the updated circle position.
                DrawPathInMaze(currentNode);

                // Delay for visualization (adjust the delay time as needed).
                System.Threading.Thread.Sleep(500);


                //int[] order = new int[] { MazeNode.North, MazeNode.South, MazeNode.East, MazeNode.West };

                // Iterate through the neighbors in a specific order (e.g., North, South, East, West).
                foreach (int neighborIndex in /*order*/ new int[] { MazeNode.North, MazeNode.South, MazeNode.East, MazeNode.West } )
                {
                    MazeNode neighbor = currentNode.Neighbors[neighborIndex];

                    if (neighbor != null && neighbor.visited == 0)
                    {
                        // Check if there is an active wall between the current node and the neighbor.
                        if (!HasActiveWall(currentNode, neighbor))
                        {
                            // Enqueue the neighbor and mark it as visited.
                            queue.Enqueue(neighbor);
                            neighbor.visited = 1;      //set neighbor as visited

                            // Update the parent map.
                            parentMap[neighbor] = currentNode;
                        }
                    }
                }
            }


        }


        private void DrawPathInMaze(MazeNode pathNode)
        {
            using (Graphics gr = Graphics.FromImage(bm))
            {

                // Clear the maze projection.
                gr.Clear(Color.White);

                // Redraw the maze.
                DisplayMaze2(nodes, gr);

                // Draw smaller "X" marks for visited nodes.
                foreach (MazeNode visitedNode in visitedNodes)
                {
                    int markSize = Math.Min(visitedNode.Bounds.Width, visitedNode.Bounds.Height) / 6; // Adjust the divisor for smaller marks
                    int markX = visitedNode.Center.X - markSize;
                    int markY = visitedNode.Center.Y - markSize;

                    gr.DrawLine(Pens.Black, markX, markY, markX + 2 * markSize, markY + 2 * markSize);
                    gr.DrawLine(Pens.Black, markX, markY + 2 * markSize, markX + 2 * markSize, markY);
                }

                // Calculate the center of the current position.
                int circleRadius = Math.Min(currentPosition.Bounds.Width, currentPosition.Bounds.Height) / 4;
                int circleX = currentPosition.Center.X - circleRadius;
                int circleY = currentPosition.Center.Y - circleRadius;
                int circleDiameter = 2 * circleRadius;

                // Adjust the circle position to ensure it's within the maze boundaries.
                if (circleX < 0)
                {
                    circleX = 0;
                }
                else if (circleX + circleDiameter > bm.Width)
                {
                    circleX = bm.Width - circleDiameter;
                }

                if (circleY < 0)
                {
                    circleY = 0;
                }
                else if (circleY + circleDiameter > bm.Height)
                {
                    circleY = bm.Height - circleDiameter;
                }

                // Draw the red/black circle at the adjusted position.
                gr.FillEllipse(Brushes.Black, circleX, circleY, circleDiameter, circleDiameter);
            }

            mazeArea.Image = bm;
            Application.DoEvents();
            System.Threading.Thread.Sleep(200); //1000
        }

        private void DisplayMaze2(MazeNode[,] nodes, Graphics gr)
        {
            int hgt = nodes.GetUpperBound(0) + 1;
            int wid = nodes.GetUpperBound(1) + 1;

            for (int r = 0; r < hgt; r++)
            {
                for (int c = 0; c < wid; c++)
                {
                    nodes[r, c].DrawWalls(gr, Pens.Black);

                    // Mark the entry point (top-left corner).
                    if (r == 0 && c == 0)
                    {
                        int markerSize = Math.Min(nodes[r, c].Bounds.Width, nodes[r, c].Bounds.Height) / 4;
                        gr.FillRectangle(Brushes.Green, nodes[r, c].Center.X - markerSize, nodes[r, c].Center.Y - markerSize, 2 * markerSize, 2 * markerSize);
                    }

                    // Mark the exit point (bottom-right corner).
                    if (r == hgt - 1 && c == wid - 1)
                    {
                        int markerSize = Math.Min(nodes[r, c].Bounds.Width, nodes[r, c].Bounds.Height) / 4;
                        gr.FillRectangle(Brushes.Red, nodes[r, c].Center.X - markerSize, nodes[r, c].Center.Y - markerSize, 2 * markerSize, 2 * markerSize);
                    }
                }
            }
        }

        private void rbDFS_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (!rbDFS.Checked) return;

                visitedNodes.Clear();
                MazeNode startNode = nodes[0, 0];
                MazeNode finishNode = nodes[nodes.GetLength(0) - 1, nodes.GetLength(1) - 1];

                DepthFirstSearch(startNode, finishNode);
            }catch (Exception ex)
            {
                MessageBox.Show("Error: Please generate maze first", "Error: Generate Maze", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool HasActiveWall(MazeNode node1, MazeNode node2)
        {
            // Determine the direction from node1 to node2.
            int direction = -1;

            for (int i = 0; i < 4; i++)
            {
                if (node1.Neighbors[i] == node2)
                {
                    direction = i;
                    break;
                }
            }

            if (direction == -1)
            {
                // The nodes are not neighbors.
                return false;
            }

            // Check if there is an active wall in the given direction.
            if ((node1.Neighbors[direction] != null) && (node1.Neighbors[direction].Predecessor != node1))
            {
                return true;
            }

            return false;
        }

        private void rbDFS_Click(object sender, EventArgs e) {    }

        private void rbBFS_Click(object sender, EventArgs e)
        {
            try
            {
                visitedNodes.Clear();
                MazeNode startNode = nodes[0, 0];
                                        // 2d array getLength(0)- rowSize/Length, 1 - columnsSize
                MazeNode finishNode = nodes[nodes.GetLength(0) - 1, nodes.GetLength(1) - 1];

                // Start the BFS traversal from the start node.
                BreadthFirstSearch(startNode, finishNode);
                System.Threading.Thread.Sleep(200); //500

            }catch(Exception ex)
            {
                MessageBox.Show("Error: Please generate maze first", "Error: Generate Maze",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

    }
}
