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
    public partial class FormBaseDrag : Form
    {
        /// <summary>
        /// 配置相关信息结构体
        /// </summary>
        public zsbApps.ControlsDragInfo ControlsDragInfo = new zsbApps.ControlsDragInfo();
        public List<string> ListControlsTreeInfo = new List<string>();

        public Dictionary<string, Control> ListControlsSelect = new Dictionary<string, Control>();

        public FormBaseDrag()
        {
            InitializeComponent();
            this.ControlsDragInfo.ListNotDrag = new List<Control>();
            this.ControlsDragInfo.slControlsName = new StringList();
            this.ControlsDragInfo.slControlsLocation = new StringList();
        }

        /// <summary>
        /// 开启拖拽配置功能
        /// </summary>
        /// <param name="c">控件</param>
        public virtual void OpenDrag(Control ct)
        {
            foreach (Control c in ct.Controls)
            {
                if (!this.ControlsDragInfo.ListNotDrag.Contains(c))
                {
                    var x = new zsbApps.SetControlsDragMove(c);
                    x.SelectedControlEvent += (ctrl) =>
                    {
                        if (!this.ListControlsSelect.ContainsKey(ctrl.Name))
                            this.ListControlsSelect.Add(ctrl.Name, ctrl);
                    };
                    x.CancelSelectedControlEvent += (ctrl) =>
                    {
                        this.ListControlsSelect = new Dictionary<string, Control>();
                        //if (this.ListControlsSelect.ContainsKey(ctrl.Name))
                            //this.ListControlsSelect.Remove(ctrl.Name);
                    };
                    x.AddEvents(); 
                }
            }
            foreach (Control c in ct.Controls)
            {
                OpenDrag(c);
            }
        }

        /// <summary>
        /// 关闭拖拽功能
        /// </summary>
        /// <param name="c">控件</param>
        public virtual void CloseDrag(Control ct)
        {
            foreach (Control c in ct.Controls)
            {
                if (!this.ControlsDragInfo.ListNotDrag.Contains(c))
                {
                    new zsbApps.SetControlsDragMove(c).DeleteEvents();
                }
            }
            foreach (Control c in ct.Controls)
            {
                CloseDrag(c);
            }
        }

        /// <summary>
        /// 保存控件的层次结构
        /// </summary>
        /// <param name="ct">控件</param>
        public virtual void SaveControlsLevelInfo(Control ct)
        {
            foreach (Control c in ct.Controls)
            {
                this.ListControlsTreeInfo.Add(c.Name);
            }
            foreach (Control c in ct.Controls)
            {
                this.ListControlsTreeInfo.Add("---");
                SaveControlsLevelInfo(c);
            }
        }

        /// <summary>
        /// 添加不允许设置拖拽的
        /// </summary>
        public virtual void AddNotDragControls()
        {

        }

        /// <summary>
        /// 载入配置信息
        /// </summary>
        /// <param name="bReset">重新加载原文件</param>
        public virtual void LoadDragInfo(bool bReset=false)
        {
            zsbApps.StringList sl = new zsbApps.StringList();
            if (bReset)
            {
                sl.LoadFromFile(this.ControlsDragInfo.FileNameSource);
            }
            else
            {
                sl.LoadFromFile(this.ControlsDragInfo.FileNameSet);
            }
            for (int i = 0; i < sl.Count(); i++)
            {
                string[] words = sl[i].ToString().Split(new char[] { ';' });
                this.ControlsDragInfo.slControlsName.Add(words[0]);
                this.ControlsDragInfo.slControlsLocation.Add(words[1]);
            }
        }


        /// <summary>
        /// 载入配置信息
        /// </summary>
        /// <param name="bReset">重新加载原文件</param>
        public virtual void SetLocationDragInfo(Control ct)
        {
            foreach (Control c in ct.Controls)
            {
                if (!this.ControlsDragInfo.ListNotDrag.Contains(c))
                {
                    for (int i = 0; i < this.ControlsDragInfo.slControlsName.Count(); i++)
                    {
                        if (c.Name == this.ControlsDragInfo.slControlsName[i].Replace("N=", ""))
                        {
                            string[] nxywh = this.ControlsDragInfo.slControlsLocation[i].ToString().Split(new char[] { '|' });
                            c.Location = new Point(getIntValue(nxywh[0].Replace("X=", "")), getIntValue(nxywh[1].Replace("Y=", "")));
                            c.Size = new Size(getIntValue(nxywh[2].Replace("W=", "")), getIntValue(nxywh[3].Replace("H=", "")));
                            c.Visible = getBoolValue(nxywh[4].Replace("V=", ""));
                        }
                    }
                }
            }
            foreach (Control c in ct.Controls)
            {
                SetLocationDragInfo(c);
            }
        }

        /// <summary>
        /// 移除FrameControl
        /// </summary>
        /// <param name="ct">控件</param>
        public virtual void DisposeFrameControl(Control ct)
        {
            foreach (Control c in ct.Controls)
            {
                if (c.Name.Contains("FrameControl"))
                {
                    c.Dispose();
                }
            }

            foreach (Control c in ct.Controls)
            {
                DisposeFrameControl(c);
            }
        }

        /// <summary>
        /// 保存位置大小信息
        /// </summary>
        /// <param name="ct">控件</param>
        /// <param name="bSource">是否保存到起始位置</param>
        /// <returns></returns>
        public virtual bool SaveDragInfo(Control ct, bool bSource=false)
        {
            DisposeFrameControl(ct);
            StringList sl = new StringList();
            GetDragInfo(ct, ref sl);
            if (bSource)
            {
                sl.SaveToFile(this.ControlsDragInfo.FileNameSource);
            }
            else
            {
                sl.SaveToFile(this.ControlsDragInfo.FileNameSet);
            }            
            return true;
        }


        /// <summary>
        /// 获取控件的位置大小信息
        /// </summary>
        /// <param name="ct">控件</param>
        /// <param name="sl">写入的文本</param>
        public virtual void GetDragInfo(Control ct, ref StringList sl)
        {
            foreach (Control c in ct.Controls)
            {
                if (!this.ControlsDragInfo.ListNotDrag.Contains(c))
                {
                    sl.Add(string.Format("N={0};X={1}|Y={2}|W={3}|H={4}|V={5}", c.Name, c.Left, c.Top, c.Width, c.Height, c.Visible));
                }
            }

            foreach (Control c in ct.Controls)
            {
                GetDragInfo(c, ref sl);
            }
        }


        public virtual int getIntValue(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return 0;
            }
            else
            {
                return Convert.ToInt16(value);
            }
        }
        public virtual bool getBoolValue(string value)
        {
            if (value == "0" || value.ToLower().Trim() == "false")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
