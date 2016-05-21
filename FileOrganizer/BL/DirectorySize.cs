using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FileOrganizer.BL
{
    public class DirectorySize
    {
        
        public string GetStringSize(string pDir)
        {
            //if (virtualPath == "")
            //    virtualPath = "/";
            //else if (virtualPath.EndsWith("/"))
            //    virtualPath = virtualPath.Substring(0, virtualPath.Length - 1);
            //string physicalPath = Server.MapPath(virtualPath);
            double folderSize = GetFolderSize(pDir);
            string strSize = FormatSize(folderSize);
            return strSize;
        }

        private double GetFolderSize(string physicalPath)
        {
            double dblDirSize = 0;
            DirectoryInfo objDirInfo = new DirectoryInfo(physicalPath);
            Array arrChildFiles = objDirInfo.GetFiles();
            Array arrSubFolders = objDirInfo.GetDirectories();
            foreach (FileInfo objChildFile in arrChildFiles)
            {
                dblDirSize += objChildFile.Length;
            }
            //foreach (FileInfo objChildFolder in arrSubFolders)
            //{
            //    dblDirSize += GetFolderSize(objChildFolder.FullName);
            //}

            foreach (DirectoryInfo objChildFolder in arrSubFolders)
            {
                dblDirSize += GetFolderSize(objChildFolder.FullName);
            }
            return dblDirSize;
        }

        public string FormatSize(double dblFileSize)
        {
            if (dblFileSize < 1024)
                return String.Format("{0:N0} B", dblFileSize);
            else if (dblFileSize < 1024 * 1024)
                return String.Format("{0:N2} KB", dblFileSize / 1024);
            else if (dblFileSize < 1024 * 1024 * 1024)
                return String.Format("{0:N2} MB", dblFileSize / (1024 * 1024));
            else if (dblFileSize >= 1024 * 1024 * 1024)
                return "Dimensione in GB!";
            else return string.Empty;
        }
    }
}
