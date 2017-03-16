using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

//郑少宝 用于窗体控件的拖动处理

namespace zsbApps
{
    public class SetControlsDragMove
    {

        #region 变量定义
        /// <summary>
        /// 传入的控件
        /// </summary>
        //private Control _currentControl; 
        /// <summary>
        /// 上个鼠标坐标
        /// </summary>
        private Point _pPoint; 
        /// <summary>
        /// 当前鼠标坐标
        /// </summary>
        private Point _cPoint; 
        /// <summary>
        /// 边框控件
        /// </summary>
        FrameControl _fc;
        /// <summary>
        /// 鼠标右键菜单
        /// </summary>
        private ContextMenuStrip _cms;
        /// <summary>
        /// 不需要拖拽的控件
        /// </summary>
        public List<Control> ListNotDrag = new List<Control>();
        /// <summary>
        /// 是否启用拖拽
        /// </summary>
        private bool _isOpenDrag;
        #endregion

        public SetControlsDragMove()
        {
            //_currentControl = c;
            this._cms = new ContextMenuStrip();

            //ToolStripMenuItem subItem;
            //subItem = AddContextMenu("显示状态", this._cms.Items, null);
            //添加子菜单 
            AddContextMenu("显示", this._cms.Items, new EventHandler(MenuClicked_Show));
            AddContextMenu("-", this._cms.Items, null);
            AddContextMenu("不显示", this._cms.Items, new EventHandler(MenuClicked_Hide)); 


        }
        /// <summary>
        /// 设置是否可以拖拽
        /// </summary>
        /// <param name="isOpen"></param>
        public void SetCanOpenDrag(bool isOpen)
        {
            this._isOpenDrag = isOpen;
            if (!isOpen)
            {
                this._fc.Dispose();
                //this._fc.Visible = false;
            }
        }

        /// <summary>
        /// 加载拖拽功能事件
        /// </summary>
        public void OpenDrag(Control ct)
        {
            foreach (Control c in ct.Controls)
            {
                if (this.ListNotDrag != null)
                {
                    if (this.ListNotDrag.Contains(c))
                    {
                        continue;
                    }
                }
                this.addDragEvents(c);
                c.ContextMenuStrip = this._cms;
            }
            foreach (Control c in ct.Controls)
            {
                OpenDrag(c);
            }
        }

        void MenuClicked_Show(object sender, EventArgs e)
        {
            this._cms.SourceControl.Visible = true;
        }
        void MenuClicked_Hide(object sender, EventArgs e)
        {
            this._cms.SourceControl.Visible = false;
            this._fc.Dispose();
        }

        /// <summary>
        /// 添加子菜单
        /// </summary>
        /// <param name="text">要显示的文字，如果为 - 则显示为分割线</param>
        /// <param name="cms">要添加到的子菜单集合</param>
        /// <param name="callback">点击时触发的事件</param>
        /// <returns>生成的子菜单，如果为分隔条则返回null</returns>
        private ToolStripMenuItem AddContextMenu(string text, ToolStripItemCollection cms, EventHandler callback)
        {
            if (text == "-")
            {
                ToolStripSeparator tsp = new ToolStripSeparator();
                cms.Add(tsp);

                return null;
            }
            else if (!string.IsNullOrEmpty(text))
            {
                ToolStripMenuItem tsmi = new ToolStripMenuItem(text);
                if (callback != null) tsmi.Click += callback;
                cms.Add(tsmi);

                return tsmi;
            }
            return null;
        } 


        #region Properties

        #endregion

        #region 方式
        /// <summary>
        /// 添加鼠标事件
        /// </summary>
        private void addDragEvents(Control c)
        {
            if (!_isOpenDrag) return;
            if(c == null) return;
            c.MouseClick += new MouseEventHandler(MouseClick);
            c.MouseDown += new MouseEventHandler(MouseDown);
            c.MouseMove += new MouseEventHandler(MouseMove);
            c.MouseUp += new MouseEventHandler(MouseUp);
            c.MouseLeave += new EventHandler(MouseLeave);
        }
        /// <summary>
        /// 删除鼠标事件
        /// </summary>
        private void deleteDragEvents(Control c)
        {
            if (!_isOpenDrag) return;
            if (c == null) return;
            c.MouseClick -= new MouseEventHandler(MouseClick);
            c.MouseDown -= new MouseEventHandler(MouseDown);
            c.MouseMove -= new MouseEventHandler(MouseMove);
            c.MouseUp -= new MouseEventHandler(MouseUp);
            c.MouseLeave -= new EventHandler(MouseLeave);
        }

        /// <summary>
        /// 绘制拖拉时的黑色边框
        /// </summary>
        public static void DrawDragBound(Control ctrl)
        {
            ctrl.Refresh();
            Graphics g = ctrl.CreateGraphics();
            int width = ctrl.Width;
            int height = ctrl.Height;
            Point[] ps = new Point[5]{new Point(0,0),new Point(width -1,0),
                new Point(width -1,height -1),new Point(0,height-1),new Point(0,0)};
            g.DrawLines(new Pen(Color.Black), ps);
        }    

        #endregion

        #region 事件
        /// <summary>
        /// 鼠标单击事件：用来显示边框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MouseClick(object sender, MouseEventArgs e)
        {
            if (!_isOpenDrag) return;
            Control ct = sender as Control;
            if ( ct is TabPage) return;
            ct.Parent.Refresh();
            ct.BringToFront();
            _fc = new FrameControl(ct);
            ct.Parent.Controls.Add(_fc);
            _fc.Visible = true;
            _fc.Draw();
        }

        /// <summary>
        /// 鼠标按下事件：记录当前鼠标相对窗体的坐标
        /// </summary>
        void MouseDown(object sender, MouseEventArgs e)
        {
            if (!_isOpenDrag) return;
            _pPoint = Cursor.Position;               
        }

        /// <summary>
        /// 鼠标移动事件：让控件跟着鼠标移动
        /// </summary>
        void MouseMove(object sender, MouseEventArgs e)
        {
            if (!_isOpenDrag) return;
            Cursor.Current = Cursors.SizeAll; //当鼠标处于控件内部时，显示光标样式为SizeAll
            //当鼠标左键按下时才触发
            if (e.Button == MouseButtons.Left)
            {
                Control ct = sender as Control;
                DrawDragBound(ct);
                if(_fc != null ) _fc.Visible = false; //先隐藏
                _cPoint = Cursor.Position;//获得当前鼠标位置
                int x = _cPoint.X - _pPoint.X;
                int y = _cPoint.Y - _pPoint.Y;
                ct.Location = new Point(ct.Location.X + x, ct.Location.Y + y);
                _pPoint = _cPoint;
            }
        }

        /// <summary>
        /// 鼠标弹起事件：让自定义的边框出现
        /// </summary>
        void MouseUp(object sender, MouseEventArgs e)
        {
            if (!_isOpenDrag) return;
            (sender as Control).Refresh();
            if (_fc != null)
            {
                _fc.Visible = true;
                _fc.Draw();
            }
        }


        /// <summary>
        /// 鼠标移开事件
        /// </summary>
        void MouseLeave(object sender, EventArgs e)
        {
            if (!_isOpenDrag) return;
            return;
            (sender as Control).Refresh();
            if (_fc != null)
            {
                _fc.Dispose();
            }
        }
        #endregion
    }
}
