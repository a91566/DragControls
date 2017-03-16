using System;
using System.IO;
using System.Text;
using System.Linq; 
using System.Collections.Generic;
using System.Runtime.InteropServices;


namespace zsbApps
{
    /// <summary>
    /// 读写配置文件的类(*.ini)
    /// </summary>
    public class InitHelper
    {
        /// <summary>
        /// 初始化类及要读取的配置文件
        /// </summary>
        /// <param name="strFile">文件名(全路径)</param>
        public InitHelper(string strFile)
        {
            if (!string.IsNullOrEmpty(strFile))
            {
                if (File.Exists(strFile))
                {
                    if (strFile.ToLower().EndsWith(".ini"))
                    {
                        this.FILE = strFile;
                    }
                }
                //2016年8月31日16:39:31 郑少宝 没有就创建
                else
                {
                    WritePrivateProfileString("[SYSCREATED]","DATETIME",DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),strFile);
                }
            }
        }

        /// <summary>
        /// 读取一个配置值
        /// </summary>
        /// <param name="strSection">节点</param>
        /// <param name="strKey">配置名</param>
        /// <returns>返回值</returns>
        public string ReadKey(string strSection, string strKey)
        {
            try
            {
                StringBuilder sb = new StringBuilder(255);//read key value
                InitHelper.GetPrivateProfileString(strSection, strKey, "", sb, 255, this.FILE);
                return sb.ToString();
            }
            catch { return string.Empty; }
            finally { }
        }


        /// <summary>
        /// 写一个配置项
        /// </summary>
        /// <param name="strSection">节点</param>
        /// <param name="strKey">配置名</param>
        /// <param name="strVal">被写入值</param>
        /// <returns>写入成功返回true,失败false</returns>
        public bool WriteKey(string strSection, string strKey, string strVal)
        {
            try
            {
                InitHelper.WritePrivateProfileString(strSection, strKey, strVal, this.FILE);
                return true;//write key
            }
            catch { return false; }
            finally { }
        }
        

        

        private string FILE = string.Empty;//配置文件全路径及文件名
        [DllImport("kernel32.dll")]
        private static extern long WritePrivateProfileString(string strSec,
        string strKey, string strVal, string strFull); 
        [DllImport("kernel32.dll")]
        private static extern int GetPrivateProfileString(string strSec, 
        string strKey, string def, StringBuilder sbReturn, int intSize, string strFull);

    } 
}
