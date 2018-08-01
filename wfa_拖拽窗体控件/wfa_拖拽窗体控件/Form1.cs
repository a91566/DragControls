using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zsbApps
{
    public partial class Form1 : zsbApps.FormBaseDrag
    {
               

        public Form1()
        {
            InitializeComponent();
            base.ControlsDragInfo.FileNameSource = System.Environment.CurrentDirectory + @"\" + this.Name + "Source.zsb";
            base.ControlsDragInfo.FileNameSet = System.Environment.CurrentDirectory + @"\" + this.Name + "Set.zsb";
        }


        private void btnSet_Click(object sender, EventArgs e)
        {
            AddNotDragControls();
            base.LoadDragInfo();
            base.OpenDrag(this);
        }


        private void btnSaveDrag_Click(object sender, EventArgs e)
        {
            base.SaveDragInfo(this);
            zsbApps.MsgShow.MsgInfo(0);
        }


        /// <summary>
        /// 加载不需要设置的控件
        /// </summary>
        public override void AddNotDragControls()
        {
            base.ControlsDragInfo.ListNotDrag.Add(this.btnSetDrag);
            base.ControlsDragInfo.ListNotDrag.Add(this.btnCloseDrag);
            base.ControlsDragInfo.ListNotDrag.Add(this.btnSaveDrag);
            base.ControlsDragInfo.ListNotDrag.Add(this.btnLoadSet);
            base.ControlsDragInfo.ListNotDrag.Add(this.btnSaveDragSource);
            base.ControlsDragInfo.ListNotDrag.Add(this.btnLoadDragSource);
            base.ControlsDragInfo.ListNotDrag.Add(this.btnSaveControlsInfo);
            base.ControlsDragInfo.ListNotDrag.Add(this.toolStrip1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            base.SaveDragInfo(this,true);
            zsbApps.MsgShow.MsgInfo(0);
        }

        private void btnLoadSet_Click(object sender, EventArgs e)
        {
            AddNotDragControls();
            base.LoadDragInfo();
            base.SetLocationDragInfo(this);
        }

        private void btnLoadDragSource_Click(object sender, EventArgs e)
        {
            AddNotDragControls();
            base.LoadDragInfo(true);
            base.SetLocationDragInfo(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnLoadSet_Click(sender,e);
        }

        private void btnSaveControlsInfo_Click(object sender, EventArgs e)
        {
            base.ListControlsTreeInfo.Add(this.Name);
            base.SaveControlsLevelInfo(this);
            string temp = string.Empty;
            foreach (var item in base.ListControlsTreeInfo)
            {
                temp =temp + item + Environment.NewLine;
            }
            zsbApps.MsgShow.MsgInfo(temp);
        }

        private void btnCloseDrag_Click(object sender, EventArgs e)
        {
            base.CloseDrag(this);
        }

        private void toolStripBtn_Left_Click(object sender, EventArgs e)
        {
            if (base.ListControlsSelect.Count == 0)
            {
                MessageBox.Show("no data");
                return;
            }
            MessageBox.Show(string.Join(System.Environment.NewLine, base.ListControlsSelect.Keys.ToList()));

            var controls = base.ListControlsSelect.Values.ToList();
            var left = controls[0].Left;
            for (int i = 1; i < controls.Count; i++)
            {
                controls[i].Left = left;
            }
        }
    }
}
