using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FileOrganizer
{
    public class TxTParser
    {
        string mFullPath = string.Empty;
        public TxTParser(string pFullPath)
        {
            mFullPath = pFullPath;
        }

        public bool IsContainTxt(string pTxTToSearch)
        {
            string fileContent = File.ReadAllText(mFullPath);

            return IsFileContentContain(fileContent , pTxTToSearch);

        }
        private bool IsFileContentContain(string pFileContent, string pTxtToSearch)
        {
            if (string.IsNullOrEmpty(pFileContent))
                return false;
            if (string.IsNullOrEmpty(pTxtToSearch))
                return false;

            if (pFileContent.ToUpper().Contains(pTxtToSearch.ToUpper()))
                return true;

            return false;
        }

    }
}
