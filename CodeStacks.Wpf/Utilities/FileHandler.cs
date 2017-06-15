using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace xiaowen.codestacks.wpf.Utilities
{
    public class FileHandler
    {
        FileHandler() { }

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
        private static void CreateFolder(string folderName)
        {
            string appFolder = Environment.CurrentDirectory;
            Directory.CreateDirectory(appFolder);
        }

        /// <summary>
        /// create file
        /// </summary>
        /// <param name="path">file absolute path</param>
        /// <param name="fileName">file name</param>
        /// <param name="content">file content</param>
        private static void CreateFile(string path, string fileName, string content)
        {
            string fullPath = Path.Combine(path, fileName);
            if (!File.Exists(fullPath))
            {
                using (FileStream fs = File.Create(fullPath))
                {
                    byte[] info = null;
                    if (!string.IsNullOrEmpty(content))
                    {
                        info = new UTF8Encoding(true).GetBytes(content);
                    }
                    else
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append("");
                        info = new UTF8Encoding(true).GetBytes(sb.ToString());
                    }

                    fs.Write(info, 0, info.Length);
                }
            }
        }

    }
}
