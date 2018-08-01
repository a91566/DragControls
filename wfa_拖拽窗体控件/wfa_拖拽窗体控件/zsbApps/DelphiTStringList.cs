using System;
using System.Text;

//郑少宝 类似Delphi的StringList

namespace zsbApps
{
    /// <summary>
    /// 字符串列表对象，可以保存多行的字符串，可以保存字符串列表到文件中，也可以从文本文件中读取，数据到字符串列表中。
    /// </summary> 
    public class StringList
    {
        private System.Collections.ArrayList Lines = new System.Collections.ArrayList();

        /// <summary>
        /// 创建一个字符串列表对象
        /// </summary>
        public StringList()
        {
        }

        /// <summary>
        /// 直接返回字符串列表的第 Index 行字符串
        /// </summary>
        /// <param name="Index">行号</param>
        /// <returns></returns>
        public string this[int Index]
        {
            get 
            {
                if (Lines.Count <= Index)
                {
                    //throw new InvalidOperationException("Index值超界啦 !");
                    return "Index值超界";
                }
                else
                {
                    return Lines[Index].ToString();
                }
            }
            set 
            {
                if (Lines.Count <= Index)
                {
                    //throw new InvalidOperationException("Index值超界啦 !");
                    Lines[Index] = "Index值超界";
                }
                else
                {
                    Lines[Index] = value;
                }
            }
        }

        /// <summary>
        /// 返回此字符串列表总行数
        /// </summary>
        /// <returns></returns>
 
        public int Count()
        {
            return Lines.Count;
        }

        /// <summary>
        /// 增加一行字符串到字符串列表中
        /// </summary>
        /// <param name="StrValue"></param>
        /// <returns></returns>
        public int Add(string StrValue)
        {
            return Lines.Add(StrValue);
        }

        /// <summary>
        /// 清除字符串列表中的所有内容
        /// </summary>
        public void Clear()
        {
            Lines.Clear();
        }

        /// <summary>
        /// 指定KeyName的值，如果字符串列表中不包含指定的KeyName，则返回空字符串
        /// </summary>
        /// <param name="KeyName"></param>
        /// <returns></returns>
        public string GetValue(string KeyName)
        {
            if (Lines.Count == 0) return "";
            for (int i = 0; i < Lines.Count; i++)
            {
                string tmpKeyName = Lines[i].ToString().Substring(0, KeyName.Length + 1).ToLower();
                if (KeyName.ToLower() + "=" == tmpKeyName)
                {
                    string tmpValue = Lines[i].ToString();
                    tmpValue = tmpValue.Substring(KeyName.Length + 1, tmpValue.Length - KeyName.Length - 1);
                    return tmpValue;
                }
            }
            return "";                            
        }

        /// <summary>
        /// 读入字符串列表中 KeyName = ??? 的值，如果指定的KeyName不存在，则自动创建
        /// </summary>
        /// <param name="KeyName"></param>
        /// <param name="KeyValue"></param>
        public void SetValue(string KeyName, string KeyValue)
        {
            int Index = -1;
            //查找 KeyName 在第几行
            if (Lines.Count != 0)
            {
                for (int i = 0; i < Lines.Count; i++)
                {
                    string tmpKeyName = Lines[i].ToString().Substring(0, KeyName.Length + 1).ToLower();
                    if (KeyName.ToLower() + "=" == tmpKeyName)
                    {
                        Index = i;
                        break;
                    }
                }
            }

            if (Index == -1)
            {
                //如果没有键则添加一个
                Lines.Add(KeyName + "=" + KeyValue);
            }
            else
            {
                //修改此键的值
                Lines[Index] = KeyName + "=" + KeyValue;
            }
        }

        /// <summary>
        /// 保存字符串列表到指定的文本文件中
        /// </summary>
        /// <param name="FileName">文件名</param>
        public void SaveToFile(string FileName)
        {                                    
            System.IO.File.WriteAllLines(FileName, (string[])Lines.ToArray(typeof(string)));
        }

        /// <summary>
        /// 从指定的文本中读取文本内容到字符串列表中
        /// </summary>
        /// <param name="FileName">文件名</param>
        /// <returns></returns>
        public bool LoadFromFile(string FileName)
        {
            if (System.IO.File.Exists(FileName) == true)
            {
                Lines.Clear();
                Lines.AddRange(System.IO.File.ReadAllLines(FileName));
                return true;
            }
            else
            {
                //throw new InvalidOperationException(FileName+" 文件不存在 !");
                return false;
            }
        }
    }
}
