using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TreeTraversal1
{
    class Adjacency:ListView
    {
        
        private const int colwidth = 30;
        private const int rowheight = 15;
        public void init()
        {
            this.Items.Clear();
            this.Columns.Clear(); 
            this.Sorting = SortOrder.None;
            this.View = View.Details;
            this.Columns.Add(new ColumnHeader());
            this.Columns[0].Text = "-";
            this.Columns[0].Width = colwidth;
            this.Width = 400;
            this.Height = 300;
        }

        public void addCell(String text)
        {
            
           
            ColumnHeader header = new ColumnHeader();
            header.Text = text;
            header.Width = colwidth;
            int n = this.Columns.Add(header);
           
            String[] texts = new String[n + 1];
            texts[0] = text;
            for (int i = 0; i < n; i++)
            {
                texts[i + 1] = "0";
            }

            this.Items.AddRange(new ListViewItem[] { new ListViewItem(texts) });

            for (int i = 0; i < n; i++)
            {
                texts[0] = "0";
                Items[i].SubItems.AddRange(texts);
               
            }
        }

        public void removeCell(String text)
        {


            ColumnHeader header = new ColumnHeader();
            header.Text = text;
            header.Width = colwidth;
            int n = this.Columns.Add(header);

            String[] texts = new String[n + 1];
            texts[0] = text;
            for (int i = 0; i < n; i++)
            {
                texts[i + 1] = "0";
            }

            this.Items.AddRange(new ListViewItem[] { new ListViewItem(texts) });
         //   this.Items.Remove(new ListViewItem[]{new ListViewItem(texts)});
            for (int i = 0; i < n; i++)
            {
                texts[0] = "0";
                Items[i].SubItems.AddRange(texts);

            }
        }


        public bool Adjacent(int X, int Y)
        {
            
            return Items[X].SubItems[Y + 1].Text == "1";
        }
    }
}
