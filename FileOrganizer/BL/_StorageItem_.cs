using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Collections.Specialized;

namespace FileOrganizer.BL
{
    public partial class StorageItemRow
    {
        //public long old_id = 0;
        public ListViewStorageItem ListViewStorageItem;

        int mInferedYear = 0;
        public int InferedYear
        {
            get { return mInferedYear; }
            //set { mInferedYear = value; }
        }

        public String NoteAsYesEmpty
        {
            get
            {
                if (IsNull(StorageItemDT.ColumnNames.NoteItemID))
                    return string.Empty;
                return "Yes";
            }
        }

       
        public string GetExtension()
        {
            string extension = string.Empty;
            extension = Path.GetExtension(this.s_FullPath);
            if (string.IsNullOrEmpty(extension))
                extension = Path.GetExtension(this.s_ItemName);
            return extension;
        }
        public bool IsFileExist()
        {
            if (string.IsNullOrEmpty(this.s_FullPath))
                return false;
            string file = Path.GetFullPath(this.s_FullPath);
            return (File.Exists(file));
        }
        public bool IsDirectoryExist()
        {
            if (string.IsNullOrEmpty(this.s_FullPath))
                return false;

            return Directory.Exists(this.s_FullPath);
        }
        public bool DeleteFile()
        {
            bool isDeleted = false;
            string file = Path.GetFullPath(this.s_FullPath);
            try
            {
                File.Delete(file);
                isDeleted = true;
            }
            catch
            {
                isDeleted = false;
            }


            return isDeleted;
        }
        public string GetHost()
        {
            string host = this.s_URL;
            if (!this.s_URL.Equals(string.Empty))
            {
                try
                {
                    UriBuilder uriBuilder = new UriBuilder(this.s_URL);
                    host = uriBuilder.Host;
                }
                catch
                {

                }
            }
            return host;
        }
        public string GetProtocolAndHost()
        {
            string host = this.s_URL;
            if (!this.s_URL.Equals(string.Empty))
            {
                try
                {
                    UriBuilder uriBuilder = new UriBuilder(this.s_URL);
                    host = uriBuilder.Scheme + "://" + uriBuilder.Host;
                }
                catch
                {

                }
            }
            return host;
        }
        public string GetURLPath()
        {
            string path = this.s_URL;
            if (!this.s_URL.Equals(string.Empty))
            {
                try
                {
                    //UriBuilder uriBuilder = new UriBuilder(this.s_URL);
                    path = Path.GetDirectoryName(this.s_URL);
                }
                catch
                {

                }
            }
            path = path.Replace(@"\", @"/");
            return path;
        }
        public string GetPathIconForStorageItem()
        {
            return GetPathIconForStorageItem(this.s_FullPath, this.s_ItemName);

        }
        public static string GetPathIconForStorageItem(string pFullPath, string pItemName)
        {
            string pathIcon = "do.dll";
            if (!string.IsNullOrEmpty(pFullPath))
                pathIcon = pFullPath;
            else if (!string.IsNullOrEmpty(pItemName))
                pathIcon = pItemName;

            return pathIcon;

        }
        public void InferYear()
        {
            string[] sList = s_Description.Split(new char[] { ' ', ',', ';', '\r', '\n' });
            int outResult = 0;
            foreach (string sWord in sList)
            {

                if (int.TryParse(sWord, out outResult))
                {
                    if (outResult >= 1900 && outResult <= 2020)
                        mInferedYear = outResult;
                    break;
                }
            }
        }
        public void Open()
        {
            //if (this.IsFileExist())
            //IsDirectoryExist()
            {
                Process process = new Process();
                process.StartInfo.FileName = this.FullPath;
                process.Start();
            }
        }
    }

    public partial class StorageItemDT
    {
        public bool LoadByFullPathLowerCase(string pFullPath)
        {
            string sql = string.Format("SELECT * FROM {0} WHERE LOWER({1}) = @{1}", base.QuerySource, ColumnNames.FullPath);
            ListDictionary l = new ListDictionary();
            l.Add(ColumnNames.FullPath , pFullPath.ToLower());
            return base.LoadFromSql(sql,l, System.Data.CommandType.Text);
        }

        public string[] GetSuitableDescriptionWords(string pInputString)
        {
            string inputDescription = pInputString;
            string[] nonMeaningWordList = new string[] {
                ":","~","!","@",
                "#","$","%","^",
                "&","*","(",")",
                "_","-","+","=",
                "{","}","\\","|",
                ",",".","?","/",
            "paper","thesis","technical","report",
            "presentation", Environment.NewLine};
            //inputDescription.Split(
            foreach (string nonMeaningWordLoop in nonMeaningWordList)
                inputDescription = inputDescription.Replace(nonMeaningWordLoop, " ");

            string[] inputWords = inputDescription.Split(' ');
            List<string> newInputWords = new List<string>();
            double num;
            foreach (string inputWordLoop in inputWords)
            {
                if (!string.IsNullOrEmpty(inputWordLoop))
                {
                    bool isNumeric = double.TryParse(inputWordLoop, out num);
                    if (!isNumeric)
                    {
                        newInputWords.Add(inputWordLoop);
                    }
                }

            }

            return newInputWords.ToArray();
        }

        public void GetSimilarStorageItems(string pInputString)
        {
            string[] inputWords = this.GetSuitableDescriptionWords(pInputString);
            this.Query.ResetWhereParameters();
            //StorageItem storageItem = new StorageItem();
            foreach (string toSearchWordLoop in inputWords)
            {
                if (this.Query.ParameterCount > 0)
                    this.Query.AddConjunction(MyConj.And);
                this.Query.OpenParenthesis();

                string toSearchWord = "%" + toSearchWordLoop + "%";

                MyParameter descParameter1 = this.Query.AddWhereParameter(StorageItemDT.Parameters.Description);
                descParameter1.Operator = MyOperand.Like;
                descParameter1.Value = toSearchWord.ToLower();
                //descParameter1.Conjuction = WhereParameter.Conj.Or;


                MyParameter descParameter2 = this.Query.AddWhereParameter(StorageItemDT.Parameters.Description);
                descParameter2.Operator = MyOperand.Like;
                descParameter2.Value = toSearchWord.ToUpper();
                descParameter2.Conjuction = MyConj.Or;

                this.Query.CloseParenthesis();
            }

            this.Query.Load();
            //return storageItem.AsList();
        }


    }
}
