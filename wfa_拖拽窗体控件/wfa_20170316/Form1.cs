using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * 此项目与另一个项目完全独立 2017年3月16日 11:43:52 郑少宝 
 */

namespace wfa_20170316
{
    public partial class Form1 : Form
    {

        private zsbApps.SetControlsDragMove _setControlsDragMove;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSetDrag_Click(object sender, EventArgs e)
        {
            if (this._setControlsDragMove == null)
            {
                this._setControlsDragMove = new zsbApps.SetControlsDragMove();
                foreach (Control item in this.Controls)
                {
                    if (item is Button)
                    {
                        this._setControlsDragMove.ListNotDrag.Add(item);
                    }
                }
                this._setControlsDragMove.SetCanOpenDrag(true);
                this._setControlsDragMove.OpenDrag(this);
            }
            this._setControlsDragMove.SetCanOpenDrag(true);
        }

        private void btnCloseDrag_Click(object sender, EventArgs e)
        {
            if (this._setControlsDragMove == null)
            {
                this._setControlsDragMove = new zsbApps.SetControlsDragMove();
            }
            this._setControlsDragMove.SetCanOpenDrag(false);
            //2017年3月16日20:51:36
        }
    }
}
