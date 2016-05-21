using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using FileOrganizer.UI;

namespace FileOrganizer.BL
{
    public class IniSimilarItems
    {


        string mIniFilePath;


        IniFile mIniFile;
        ListViewStorage mListViewStorage;
        string mPrefix = "LstSimilar";
        public IniSimilarItems(ListViewStorage pListViewStorage)
        {
            mListViewStorage = pListViewStorage;
            string exePath = Path.GetFullPath(Application.ExecutablePath);
            FileInfo fInfo = new FileInfo(exePath);
#if BOOK
            mIniFilePath = fInfo.Directory.FullName + Path.DirectorySeparatorChar + "StorageItemBook.ini";
#else
            mIniFilePath = fInfo.Directory.FullName + Path.DirectorySeparatorChar + "StorageItem.ini";
#endif

        }

        void WriteValue(string pKey, string pValue)
        {
            mIniFile.IniWriteValue(string.Empty, pKey, pValue);
        }
        void WriteValue(string pKey, int pValue)
        {
            mIniFile.IniWriteValue(string.Empty, pKey, pValue.ToString());
        }

        public void Save()
        {
            //Helper.MSG("Save");
            mIniFile = new IniFile(mIniFilePath);

            foreach (ColumnHeader col in mListViewStorage.Columns)
            {
                WriteValue(mPrefix  + col.Index, col.Width);

            }


        }
        private string ReadValueAsString(string pKey)
        {
            return mIniFile.IniReadValue(string.Empty, pKey);
        }
        private int ReadValueAsInt(string pKey)
        {
            return int.Parse(ReadValueAsString(pKey));
        }
        public void Load()
        {
            mIniFile = new IniFile(mIniFilePath);
            foreach (ColumnHeader col in mListViewStorage.Columns)
            {
                col.Width = ReadValueAsInt(mPrefix + col.Index);

            }



        }

    }
}
