using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
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
        protected string FieldName;

        protected void ResetNodeBackColor()
        {
            while (NodesWithColor.Count > 0)
            {
                var node = NodesWithColor.Dequeue();
                node.Override.NodeAppearance.ResetBackColor();
            }
        }
        /// <summary>
        /// 在MouseDown事件中获取激活行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        protected static UltraGridRow GetActiveRow(object sender, MouseEventArgs e)
        {
            var activedGrid = sender as UltraGrid;
            var point = new Point(e.X, e.Y);
            var objUiElement = activedGrid?.DisplayLayout.UIElement.ElementFromPoint(point);
            if (objUiElement == null)
                return null;
            var objRow = (UltraGridRow)objUiElement.GetContext(typeof(UltraGridRow));
            activedGrid.ActiveRow = objRow;
            return objRow;
        }
    }
}