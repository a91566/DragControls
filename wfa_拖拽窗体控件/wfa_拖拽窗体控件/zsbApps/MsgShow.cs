using System.Windows.Forms;

/*
 * 2012年8月25日19:03:22 郑少宝
 * 2016年11月3日14:17:17 郑少宝
 */
namespace zsbApps
{
    public class MsgShow
    {
        public MsgShow()
        {

        }

        #region 文本
        /// <summary>
        /// 信息提示
        /// </summary>
        /// <param name="strShow">提示内容</param>
        /// <param name="strTitle">标题</param>
        public static void MsgInfo(string strShow, string strTitle = "系统消息")
        {
            MessageBox.Show(strShow, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 错误提示
        /// </summary>
        /// <param name="strShow">提示内容</param>
        /// <param name="strTitle">标题</param>
        public static void MsgError(string strShow, string strTitle = "系统消息")
        {
            MessageBox.Show(strShow, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// 询问框
        /// </summary>
        /// <param name="strShow">询问内容</param>
        /// <param name="strTitle">标题</param>
        /// <returns>true/false</returns>
        public static bool MsgOK(string strShow, string strTitle = "系统消息")
        {
            DialogResult dr;
            dr = MessageBox.Show(strShow, strTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 行号传参


        private static string[] _TipsText;
        public static string[] TipsText
        {
            get 
            {
                if (_TipsText == null)
                {
                    _TipsText = new string[10000];
                    _TipsText[0] = "操作成功.";
                    _TipsText[1] = "操作失败.";
                    _TipsText[2] = "操作受限.";
                    _TipsText[3] = "样品(组)录入完毕.";                    
                }
                return _TipsText;
            }
        }

        private static string iniFileName = Application.StartupPath + (Application.StartupPath.EndsWith("\\") ? string.Empty : "\\") + "TipsText.ini";

        /// <summary>
        /// 信息提示
        /// </summary>
        /// <param name="lineNo">提示内容的行号</param>
        /// <param name="strTitle">标题</param>
        public static void MsgInfo(int lineNo, string strTitle = "系统消息")
        {
            MessageBox.Show(lineNo < 100000 ? TipsText[lineNo]: new InitHelper(iniFileName).ReadKey("SYSTEM", lineNo.ToString()), strTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 错误提示
        /// </summary>
        /// <param name="lineNo">提示内容的行号</param>
        /// <param name="strTitle">标题</param>
        public static void MsgError(int lineNo, string strTitle = "系统消息")
        {
            MessageBox.Show(lineNo < 100000 ? TipsText[lineNo] : new InitHelper(iniFileName).ReadKey("SYSTEM", lineNo.ToString()), strTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// 询问框
        /// </summary>
        /// <param name="lineNo">询问内容的行号</param>
        /// <param name="strTitle">标题</param>
        /// <returns>true/false</returns>
        public static bool MsgOK(int lineNo, string strTitle = "系统消息")
        {
            DialogResult dr;
            string temp = lineNo < 100000 ? TipsText[lineNo] : new InitHelper(iniFileName).ReadKey("SYSTEM", lineNo.ToString());
            if (temp.Contains("[NewLine]"))
            {
                string[] words = temp.Split(new char[9]{'[','N','e','w','L','i','n','e',']'});
                temp="";
                foreach (string i in words)
                {
                    temp += i.ToString() == "" ? "" : i.ToString() + "\r\n\r\n";
                }

            }
            dr = MessageBox.Show(temp, strTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion
    }
}
