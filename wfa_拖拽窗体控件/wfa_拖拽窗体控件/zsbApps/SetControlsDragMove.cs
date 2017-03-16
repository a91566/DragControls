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
        private Control _currentControl; //传入的控件
        private Point _pPoint; //上个鼠标坐标
        private Point _cPoint; //当前鼠标坐标
        FrameControl _fc;//边框控件
        private ContextMenuStrip _cms;//鼠标右键菜单
        #endregion

        public SetControlsDragMove(Control c)
        {
            _currentControl = c;
            this._cms = new ContextMenuStrip();

            //ToolStripMenuItem subItem;
            //subItem = AddContextMenu("显示状态", this._cms.Items, null);
            //添加子菜单 
            AddContextMenu("显示", this._cms.Items, new EventHandler(MenuClicked_Show));
            AddContextMenu("-", this._cms.Items, null);
            AddContextMenu("不显示", this._cms.Items, new EventHandler(MenuClicked_Hide)); 


            c.ContextMenuStrip = this._cms;
        }

        void MenuClicked_Show(object sender, EventArgs e)
        {
            this._cms.SourceControl.Visible = true;
        }
        void MenuClicked_Hide(object sender, EventArgs e)
        {
            this._cms.SourceControl.Visible = false;
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
        public void AddEvents()
        {
            _currentControl.MouseClick += new MouseEventHandler(MouseClick);
            _currentControl.MouseDown += new MouseEventHandler(MouseDown);
            _currentControl.MouseMove += new MouseEventHandler(MouseMove);
            _currentControl.MouseUp += new MouseEventHandler(MouseUp);
            _currentControl.MouseLeave += new EventHandler(MouseLeave);
        }
        /// <summary>
        /// 删除鼠标事件
        /// </summary>
        public void DeleteEvents()
        {
            _currentControl.MouseClick -= new MouseEventHandler(MouseClick);
            _currentControl.MouseDown -= new MouseEventHandler(MouseDown);
            _currentControl.MouseMove -= new MouseEventHandler(MouseMove);
            _currentControl.MouseUp -= new MouseEventHandler(MouseUp);
            _currentControl.MouseLeave -= new EventHandler(MouseLeave);

            _currentControl.Parent.MouseClick -= new MouseEventHandler(MouseClick);
            _currentControl.Parent.MouseDown -= new MouseEventHandler(MouseDown);
            _currentControl.Parent.MouseMove -= new MouseEventHandler(MouseMove);
            _currentControl.Parent.MouseUp -= new MouseEventHandler(MouseUp);
            _currentControl.Parent.MouseLeave -= new EventHandler(MouseLeave);
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
        protected void MouseClick(object sender, MouseEventArgs e)
        {
            this._currentControl.Parent.Refresh();
            this._currentControl.BringToFront();
            _fc = new FrameControl(this._currentControl);
            this._currentControl.Parent.Controls.Add(_fc);
            _fc.Visible = true;
            _fc.Draw();
        }

        /// <summary>
        /// 鼠标按下事件：记录当前鼠标相对窗体的坐标
        /// </summary>
        void MouseDown(object sender, MouseEventArgs e)
        {            
            _pPoint = Cursor.Position;               
        }

        /// <summary>
        /// 鼠标移动事件：让控件跟着鼠标移动
        /// </summary>
        void MouseMove(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.SizeAll; //当鼠标处于控件内部时，显示光标样式为SizeAll
            //当鼠标左键按下时才触发
            if (e.Button == MouseButtons.Left)
            {
                SetControlsDragMove.DrawDragBound(this._currentControl);
                if(_fc != null ) _fc.Visible = false; //先隐藏
                _cPoint = Cursor.Position;//获得当前鼠标位置
                int x = _cPoint.X - _pPoint.X;
                int y = _cPoint.Y - _pPoint.Y;
                _currentControl.Location = new Point(_currentControl.Location.X + x, _currentControl.Location.Y + y);
                _pPoint = _cPoint;
            }
        }

        /// <summary>
        /// 鼠标弹起事件：让自定义的边框出现
        /// </summary>
        void MouseUp(object sender, MouseEventArgs e)
        {
            this._currentControl.Refresh();
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
            return;
            this._currentControl.Refresh();
            if (_fc != null)
            {
                _fc.Dispose();
            }
        }
        #endregion
    }
}
