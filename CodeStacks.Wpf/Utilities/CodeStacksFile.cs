using System;
using System.IO;
using System.Text;
using Xiaowen.CodeStacks.Data.Models.Enumerate;

namespace Xiaowen.CodeStacks.Wpf.Utilities
{
    [CLSCompliant(false)]
    public class CodeStacksFile
    {
        CodeStacksFile() { }

        #region delegate
        Action<string> _createFolderCmd = CreateFolder;
        /// <summary>
        /// create directory
        /// </summary>
        public Action<string> CreateFolderCmd
        {
            get { return _createFolderCmd; }
            set { _createFolderCmd = value; }
        }
        #endregion

        /// <summary>
        /// create folder
        /// </summary>
        /// <param name="folderName">folder name</param>
        public static void CreateFolder(string folderName)
        {
            string appFolder = Environment.CurrentDirectory;
            Directory.CreateDirectory(appFolder);
        }

        /// <summary>
        /// create file
        /// </summary>
        /// <param name="path">file absolute path</param>
        /// <param name="fileName">file name,必须包含扩展名</param>
        /// <param name="content">file content</param>
        /// <param name="defaultContent">defaultContent</param>
        public static bool CreateFile(string path, string fileName, string content, string defaultContent)
        {
            bool result = false;
            bool isPath = Directory.Exists(path);
            if (!isPath)
            {
                Directory.CreateDirectory(path);
            }

            string fullPath = Path.Combine(path, fileName);
            if (!File.Exists(fullPath))
            {
                using (FileStream fs = File.Create(fullPath))
                {
                    try
                    {
                        byte[] info = null;
                        if (!string.IsNullOrEmpty(content))
                        {
                            info = new UTF8Encoding(true).GetBytes(content);
                        }
                        else
                        {
                            info = new UTF8Encoding(true).GetBytes(defaultContent);
                        }

                        fs.Write(info, 0, info.Length);
                        result = true;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message, ex);
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        public static void CreateDirectory(string path)
        {

        }

        #region File Size

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="units"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static double GetFileSize(string filePath, SizeUnitsEnum units, ref string msg)
        {
            FileInfo fileInfo = new FileInfo(filePath);
            double fileSize = 0;
            switch (units)
            {
                case SizeUnitsEnum.bit:
                    break;
                case SizeUnitsEnum.Byte:
                    fileSize = fileInfo.Length;
                    msg = fileSize + "B";
                    break;
                case SizeUnitsEnum.KByte:
                    fileSize = fileInfo.Length / 1024;
                    msg = fileSize + "KB";
                    break;
                case SizeUnitsEnum.MByte:
                    fileSize = fileInfo.Length / 1024 / 1024;
                    msg = fileSize + "MB";
                    break;
                case SizeUnitsEnum.GByte:
                    fileSize = fileInfo.Length / 1024 / 1024 / 1024;
                    msg = fileSize + "GB";
                    break;
                case SizeUnitsEnum.TByte:
                    fileSize = fileInfo.Length / 1024 / 1024 / 1024 / 1024;
                    msg = fileSize + "TB";
                    break;
                default:
                    break;
            }
            return fileSize;
        }

        #endregion
        
    }
}
