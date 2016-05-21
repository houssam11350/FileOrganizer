using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileOrganizer
{
    public enum  FileEntryType  {NON, PDF , DOCX, TXT};
    public class FileEntry
    {
        string mFilePath;
        public string FilePath
        {
            get { return mFilePath; }
            set { mFilePath = value; }
        }


        bool mIsContain;
        public bool IsContain
        {
            get { return mIsContain; }
            set { mIsContain = value; }
        }

        int mOriginalIndex;
        public int OriginalIndex
        {
            get { return mOriginalIndex; }
            set { mOriginalIndex = value; }
        }

        FileEntryType mFileEntryType = FileEntryType.NON;
        public FileEntryType FileEntryType
        {
            get { return mFileEntryType; }
            set { mFileEntryType = value; }
        }

        public FileEntry(string pFilePath, bool pIsContain, int pOriginalIndex , FileEntryType pFileEntryType)
        {
            mFilePath = pFilePath;
            mIsContain = pIsContain;
            mOriginalIndex = pOriginalIndex;
            mFileEntryType = pFileEntryType;
        }

        public FileEntry()
        {
            mFilePath = string.Empty;
            mIsContain = false;
            mOriginalIndex = -1;
        }


    }
}
