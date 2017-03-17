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
                    if (item is Button || item is TabPage)
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
        }

        private void btnSaveControlsInfo_Click(object sender, EventArgs e)
        {

        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            Control result = getControl();
            if (result != null)
            {
                result.Parent = this;
                result.Location = new Point(0, 0);
                DragControlInfo dci = result.Tag as DragControlInfo;
                dci.ParentName = this.Name;
            }            
        }
        private Control getControl()
        {
            Func<string[]> getDragControlType = () =>
            {
                StringBuilder sb = new StringBuilder();
                foreach (var item in Enum.GetNames(typeof(DragControlType)))
                {
                    sb.Append(item+",");                    
                }
                sb = sb.Remove(sb.Length-1,1);
                return sb.ToString().Split(new char[] { ',' });
            };

            Control result = null;
            Form f = new Form();
            f.BackColor = Color.White;
            f.Font = this.Font;
            f.Size = new Size(600, 400);
            f.StartPosition = FormStartPosition.CenterScreen;
            TableLayoutPanel tlp = new TableLayoutPanel();
            tlp.Dock = DockStyle.Fill;
            tlp.Parent = f;
            tlp.RowCount = 5;
            tlp.ColumnCount = 3;
            tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100));
            tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200));
            tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100));
            for (int i = 0; i < tlp.RowCount; i++)
            {
                tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40));
            }
            Action<int, int, Control> addControl = (i, j, ct) =>
            {
                if (ct is TextBox || ct is ComboBox)
                {
                    ct.Size = new Size(200, 30);
                    ct.Anchor = AnchorStyles.Left;
                    ct.AutoSize = true;
                }
                else
                {
                    ct.Dock = DockStyle.Fill;
                    ct.AutoSize = false;
                }
                tlp.Controls.Add(ct);
                tlp.SetRow(ct, i);
                tlp.SetColumn(ct, j);
            };
            Action<int, int, string> addLabel = (i, j, text) =>
            {
                Label lbl = new Label();
                lbl.Text = text;
                lbl.TextAlign = ContentAlignment.MiddleRight;
                addControl(i, j, lbl);
            };
            addLabel(0, 0, "控件名称");
            TextBox txbName = new TextBox();
            txbName.Multiline = false;
            addControl(0, 1, txbName);

            addLabel(1, 0, "控件类型");
            ComboBox comType = new ComboBox();
            comType.DropDownStyle = ComboBoxStyle.DropDownList;
            comType.Items.AddRange(getDragControlType());
            comType.SelectedIndex = 0;
            addControl(1, 1, comType);

            Button btnOk = new Button();
            btnOk.Text = "确认";
            btnOk.Click += (s, e) =>
            {
                switch (comType.SelectedIndex)
                {
                    case (int)DragControlType.单行文本框:
                        result = new TextBox();
                        result.Name = "txb" + txbName.Text.Trim();
                        result.Tag = new DragControlInfo() {
                            Name = result.Name
                        };
                        f.Close();
                        break;
                    case (int)DragControlType.可编辑下拉框:
                        result = new ComboBox();
                        result.Name = "cmb" + txbName.Text.Trim();
                        result.Tag = new DragControlInfo() {
                            Name = result.Name
                        };
                        f.Close();
                        break;
                    default:
                        f.Close();
                        break;
                }
            };
            Button btnClose = new Button();
            btnClose.Text = "取消";
            btnClose.Click += (s, e) => f.Close();
            addControl(4, 0, btnOk);
            addControl(4, 1, btnClose);


            f.ShowDialog();
            return result;
        }

        private void btnSaveDrag_Click(object sender, EventArgs e)
        {
            string filename = "123.txt";
            StringBuilder sb = new StringBuilder();
            save(this, ref sb);
            using (var fs = new System.IO.FileStream(filename, System.IO.FileMode.Create))
            {
                using (var sw = new System.IO.StreamWriter(fs))
                {
                    sw.WriteLine(sb.ToString());
                    sw.Flush();
                }
            }
            System.Diagnostics.Process.Start(filename);
            MessageBox.Show("OK");
        }

        private void save(Control ct, ref StringBuilder sb)
        {
            foreach (Control item in ct.Controls)
            {
                if (item.Tag is DragControlInfo)
                {
                    DragControlInfo c = item.Tag as DragControlInfo;
                    sb.Append(string.Format("N={0}|P={1},X={2}|Y={3}|W={4}|H={5}|V={6};", c.Name, c.ParentName, c.Location.X, c.Location.Y, c.Size.Width, c.Size.Height, c.Visable));
                }
            }
            foreach (Control item in ct.Controls)
            {
                save(item, ref sb);
            }
        }
    }

    /// <summary>
    /// 控件类型
    /// </summary>
    public enum DragControlType
    {
        /// <summary>
        /// 单行文本框
        /// </summary>
        单行文本框,
        /// <summary>
        /// 多行文本框
        /// </summary>
        多行文本框,
        /// <summary>
        /// 可编辑下拉框
        /// </summary>
        可编辑下拉框,
        /// <summary>
        /// 不可编辑下拉框
        /// </summary>
        不可编辑下拉框
    }

    /// <summary>
    /// 控件配置的信息
    /// </summary>
    public class DragControlInfo
    {
        /// <summary>
        /// 类型
        /// </summary>
        public DragControlType DragControlType { get; set; }
        /// <summary>
        /// 父级控件名称
        /// </summary>
        public string ParentName;
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 大小
        /// </summary>
        public Size Size { get; set; }
        /// <summary>
        /// 控件位置
        /// </summary>
        public Point Location { get; set; }
        /// <summary>
        /// 可见
        /// </summary>
        public bool Visable { get; set; }

        public DragControlInfo()
        {
            this.Size = new Size(0, 0);
            this.Location = new Point(0, 0);
            this.Visable = true;            
        }
    }
}
