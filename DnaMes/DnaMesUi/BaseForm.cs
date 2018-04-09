using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Infragistics.Win.UltraWinTree;

namespace DnaMesUi
{
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();
        }

        protected readonly Queue<UltraTreeNode> NodesWithColor = new Queue<UltraTreeNode>();

        protected void ResetNodeBackColor()
        {
            while (NodesWithColor.Count > 0)
            {
                var node = NodesWithColor.Dequeue();
                node.Override.NodeAppearance.ResetBackColor();
            }
        }
    }
}