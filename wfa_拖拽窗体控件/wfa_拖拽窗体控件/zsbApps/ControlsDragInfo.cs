using System.Collections.Generic;
using System.Windows.Forms;

namespace zsbApps
{
    public struct ControlsDragInfo
    {
        /// <summary>
        /// 源排版文件名称
        /// </summary>
        public string FileNameSource;
        /// <summary>
        /// 排版后的文件名称
        /// </summary>
        public string FileNameSet;
        /// <summary>
        /// 不需要拖拽的控件
        /// </summary>
        public List<Control> ListNotDrag;
        /// <summary>
        /// 文件的字符串名称
        /// </summary>
        public zsbApps.StringList slControlsName;
        /// <summary>
        /// 文件的字符串位置
        /// </summary>
        public zsbApps.StringList slControlsLocation;
    }
}
