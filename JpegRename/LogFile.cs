using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace JpegRename
{
    public class LogFile
    {
        #region Private Method
        private static int _GetValueInt(string filename, string Key)
        {
            int val = 0;
            string stringValue;
            try
            {
                stringValue = GetValue(filename, Key);
                if (stringValue == null)
                {
                    val = -999;
                }
                else
                    val = Convert.ToInt32(stringValue);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("SettingFile : GetValueInt() - " + ex.Message);
                val = -1000;
            }
            return val;
        }

        private static string _GetValue(string filename, string Key)
        {
            string settingsFileName = string.Empty;
            if (filename == string.Empty)
            {
                settingsFileName = System.Environment.CommandLine;
            }
            else
            {
                settingsFileName = filename;
            }
            try
            {
                if (File.Exists(settingsFileName) == false)
                    return null;
                StreamReader sr = new StreamReader(settingsFileName);
                if (sr != null)
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        line.Trim();
                        if (line.Length > 0 && line.StartsWith("<add key=\"" + Key + "\""))
                        {
                            int pos1 = line.IndexOf("value=\"");
                            if (pos1 >= 0)
                            {
                                pos1 += "value=\"".Length;
                                int pos2 = line.IndexOf("\"", pos1);
                                if (pos2 >= 0)
                                {
                                    sr.Close();
                                    return line.Substring(pos1, pos2 - pos1);
                                }
                            }
                        }
                    }
                    sr.Close();
                    return null;
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Cannot open settings file[" + settingsFileName + "].");
                    return null;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("SettingFile : GetValue() - " + ex.Message);
                return null;
            }
        }

        private static void _SetValue(string filename, string key, string newValue)
        {
            string oldValue;
            string oldLine;
            string newLine;
            string mContents;
            try
            {
                string settingsFileName = string.Empty;
                if (filename == string.Empty)
                {
                    settingsFileName = System.Environment.CommandLine;
                }
                else
                {
                    settingsFileName = filename;
                }

                oldValue = _GetValue(filename, key);

                newLine = "<add key=\"" + key + "\" value=\"" + newValue + "\">";

                if (File.Exists(settingsFileName) == true)
                {
                    StreamReader sr = new StreamReader(settingsFileName);
                    mContents = sr.ReadToEnd();
                    sr.Close();
                    sr = null;
                }
                else
                    mContents = string.Empty;

                StreamWriter sw = null;
                if (File.Exists(settingsFileName) == true)
                {
                    File.Delete(settingsFileName);
                }

                if (sw == null)
                {
                    sw = new StreamWriter(settingsFileName);
                }

                //offset = mContents.IndexOf("<add key=\"" + key, 0);
                if (oldValue == null)
                {
                    mContents = mContents.Trim("\r\n".ToCharArray());
                    mContents = mContents + "\r\n" + newLine;
                }
                else
                {
                    oldLine = "<add key=\"" + key + "\" value=\"" + oldValue + "\">";
                    mContents = mContents.Replace(oldLine, newLine);
                }
                sw.Write(mContents);
                sw.Flush();
                sw.Close();
                return;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("SettingFile : SetValue() - " + ex.Message);
                return;
            }
        }

        private static void _WriteLog(string filename, string message)
        {
            try
            {
                string settingsFileName = string.Empty;
                if (filename == string.Empty)
                {
                    settingsFileName = System.Environment.CommandLine;
                }
                else
                {
                    settingsFileName = filename;
                }

                if (Directory.Exists(GlobalDefine.LOGDIR) == false)
                    Directory.CreateDirectory(GlobalDefine.LOGDIR);

                StreamWriter sw = new StreamWriter(settingsFileName, true);
                sw.WriteLine(message);
                sw.Flush();
                sw.Close();
                return;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("SettingFile : _WriteLog() - " + ex.ToString());
                return;
            }
        }


        private static void _RemoveKey(string filename, string key)
        {
            int offset = 0;
            int endPos = 0;
            string oldLine;
            string mContents;

            try
            {
                string settingsFileName = string.Empty;
                if (filename == string.Empty)
                {
                    settingsFileName = System.Environment.CommandLine;
                }
                else
                {
                    settingsFileName = filename;
                }

                StreamReader sr = new StreamReader(settingsFileName);
                mContents = sr.ReadToEnd();
                sr.Close();
                sr = null;

                StreamWriter sw = null;
                if (File.Exists(settingsFileName) == true)
                {
                    File.Delete(settingsFileName);
                }

                if (sw == null)
                {
                    sw = new StreamWriter(settingsFileName);
                }
                while ((offset = mContents.IndexOf("<add key=\"" + key + "\"", offset)) != -1)
                {
                    endPos = mContents.IndexOf("\n", offset);
                    if (endPos == -1)
                        endPos = mContents.Length - 1;
                    oldLine = mContents.Substring(offset, endPos - offset + 1);
                    mContents = mContents.Replace(oldLine, "");
                }

                sw.Write(mContents);
                sw.Flush();
                sw.Close();
                return;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("SettingFile : _RemoveKey() - " + ex.Message);
                return;
            }
        }

        private static void _RemoveGroup(string filename, string group)
        {
            int offset = 0;
            int endPos = 0;
            string oldLine;
            string mContents;

            try
            {
                string settingsFileName = string.Empty;
                if (filename == string.Empty)
                {
                    settingsFileName = System.Environment.CommandLine;
                }
                else
                {
                    settingsFileName = filename;
                }

                StreamReader sr = new StreamReader(settingsFileName);
                mContents = sr.ReadToEnd();
                sr.Close();
                sr = null;

                StreamWriter sw = null;
                if (File.Exists(settingsFileName) == true)
                {
                    File.Delete(settingsFileName);
                }

                if (sw == null)
                {
                    sw = new StreamWriter(settingsFileName);
                }
                while ((offset = mContents.IndexOf("<add key=\"" + group, offset)) != -1)
                {
                    endPos = mContents.IndexOf("\n", offset);
                    if (endPos == -1)
                        endPos = mContents.Length - 1;
                    oldLine = mContents.Substring(offset, endPos - offset + 1);
                    mContents = mContents.Replace(oldLine, "");
                }

                sw.Write(mContents);
                sw.Flush();
                sw.Close();
                return;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("SettingFile : RemoveGroup() - " + ex.Message);
                return;
            }
        }
        #endregion Private Method

        #region Static Method
        public static int GetValueInt(string Key)
        {
            return _GetValueInt(string.Empty, Key);
        }

        public static int GetValueInt(string filename, string key)
        {
            return _GetValueInt(filename, key);
        }

        public static string GetValue(string Key)
        {
            return _GetValue(string.Empty, Key);
        }

        public static string GetValue(string filename, string Key)
        {
            return _GetValue(filename, Key);
        }

        public static void SetValue(string key, string value)
        {
            _SetValue(string.Empty, key, value);
        }

        public static void SetValue(string filename, string key, string value)
        {
            _SetValue(filename, key, value);
        }

        public static void RemoveKey(string key)
        {
            _RemoveKey(string.Empty, key);
        }

        public static void RemoveKey(string filename, string key)
        {
            _RemoveKey(filename, key);
        }

        public static void RemoveGroup(string group)
        {
            _RemoveGroup(string.Empty, group);
        }

        public static void RemoveGroup(string filename, string group)
        {
            _RemoveGroup(filename, group);
        }

        public static void WriteLog(string message)
        {
            _WriteLog(string.Empty, message);
        }

        public static void WriteLog(string filename, string message)
        {
            _WriteLog(filename, message);
        }

        #endregion Static Method
    }
}
