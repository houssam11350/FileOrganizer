using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using FileOrganizer.UI;

namespace FileOrganizer.BL
{
    public class IniStorageItem
    {

        const string X_POSITION = "xposition";
        const string Y_POSITION = "yposition";
        const string MAIN_WINDOW_WIDTH = "mainwindowwidth";
        const string MAIN_WINDOW_HEIHT = "mainwindowheight";
        const string STORAGE_ITEM_SELECTED_INDEX = "storage_item_selected_index";
        //const string SPLIT_CONTAINER_MAIN_ITEM = "splitContainerMainItem";
        //const string SPLIT_CONTAINER_REF = "splitContainerRef";
        const string MAIN_STORAGE_ITEM_ID = "main_storage_item_id";
        const string TOP_N = "top_n";

        string mIniFilePath;

        FrmMain mFrmMain;
        IniFile mIniFile;
        public IniStorageItem(FrmMain pFrmMain)
        {
            mFrmMain = pFrmMain;
            string exePath = Path.GetFullPath(Application.ExecutablePath);
            FileInfo fInfo = new FileInfo(exePath);
            mIniFilePath = fInfo.Directory.FullName + Path.DirectorySeparatorChar + "StorageItem.ini";

        }

        void WriteValue(string pKey, string pValue)
        {
            mIniFile.IniWriteValue(string.Empty, pKey, pValue);
        }
        void WriteValue(string pKey, int pValue)
        {
            mIniFile.IniWriteValue(string.Empty, pKey, pValue.ToString());
        }
        void WriteValue(string pKey, bool pValue)
        {
            mIniFile.IniWriteValue(string.Empty, pKey, pValue.ToString());
        }

        public void Save()
        {
            mIniFile = new IniFile(mIniFilePath);

            WriteValue(X_POSITION, mFrmMain.Location.X);
            WriteValue(Y_POSITION, mFrmMain.Location.Y);
            WriteValue(MAIN_WINDOW_WIDTH, mFrmMain.Width);
            WriteValue(MAIN_WINDOW_HEIHT, mFrmMain.Height);

            foreach (ColumnHeader col in mFrmMain.lstStorageItem.Columns)
            {
                WriteValue("ColStorageItem" + col.Index, col.Width);

            }


            int lSelectedIndex = -1;
            if (mFrmMain.lstStorageItem.SelectedIndices.Count > 0)
                lSelectedIndex = mFrmMain.lstStorageItem.SelectedIndices[0];

            WriteValue(STORAGE_ITEM_SELECTED_INDEX, lSelectedIndex);
            WriteValue(mFrmMain.splitContainer.Name, mFrmMain.splitContainer.SplitterDistance);
            WriteValue(mFrmMain.splitContainerTree.Name, mFrmMain.splitContainerTree.SplitterDistance.ToString());

            //foreach (ColumnHeader col in mFrmMain.lstRef.Columns)
            //{
            //    WriteValue("mLstRef" + col.Index, col.Width);

            //}
            //WriteValue(SPLIT_CONTAINER_MAIN_ITEM, mFrmMain.splitContainerMainItem.SplitterDistance.ToString());
            //WriteValue(SPLIT_CONTAINER_REF, mFrmMain.splitContainerRef.SplitterDistance.ToString());
            long lMainStorageItemID = -1;
            if (mFrmMain.MainStorageItem != null)
                lMainStorageItemID = mFrmMain.MainStorageItem.ID;
            WriteValue(MAIN_STORAGE_ITEM_ID, lMainStorageItemID.ToString());

            //WriteValue(mFrmMain.splitContainerGroupBySite.Name, mFrmMain.splitContainerGroupBySite.SplitterDistance.ToString());
            WriteValue(mFrmMain.splitContainerReferenceTree.Name, mFrmMain.splitContainerReferenceTree.SplitterDistance.ToString());
            WriteValue(mFrmMain.splitContainerStorageItem.Name, mFrmMain.splitContainerStorageItem.SplitterDistance.ToString());
            WriteValue(mFrmMain.splitContainerSiteGroup.Name, mFrmMain.splitContainerSiteGroup.SplitterDistance.ToString());
            WriteValue(mFrmMain.ctrlReferenceNavigator.Name, mFrmMain.ctrlReferenceNavigator.GetStorageItemIDsAsString());
            WriteValue(mFrmMain.chkAllowLstStorageMultiSelect.Name, mFrmMain.chkAllowLstStorageMultiSelect.Checked.ToString());
            WriteValue(mFrmMain.chkClearPrevResult.Name, mFrmMain.chkClearPrevResult.Checked.ToString());
            WriteValue(mFrmMain.chkSearchInAllCategories.Name, mFrmMain.chkSearchInAllCategories.Checked.ToString());
            WriteValue(mFrmMain.splitContainerSimilarItems.Name, mFrmMain.splitContainerSimilarItems.SplitterDistance.ToString());
            WriteValue(mFrmMain.splitContainerGroupStorage.Name, mFrmMain.splitContainerGroupStorage.SplitterDistance.ToString());
            //WriteValue(mFrmMain.splitContainerAllQuickList.Name, mFrmMain.splitContainerAllQuickList.SplitterDistance.ToString());
            WriteValue(mFrmMain.cmbTopN.Name, mFrmMain.cmbTopN.SelectedItem.ToString());
            WriteValue("IsSameSiteLoadingEnabled", Options.GetInstance().IsSameSiteLoadingEnabled);
            WriteValue("IsSimilarItemsLoad", Options.GetInstance().IsSimilarItemsLoad);
            WriteValue("IsQuickListLoad", Options.GetInstance().IsQuickListLoad);
            WriteValue("IsIDM", Options.GetInstance().IsIDM);
            WriteValue(mFrmMain.chkShowHint.Name, mFrmMain.chkShowHint.Checked.ToString());

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
            int x = ReadValueAsInt(X_POSITION);
            int y = ReadValueAsInt(Y_POSITION);
            mFrmMain.Location = new System.Drawing.Point(x, y);
            mFrmMain.Width = ReadValueAsInt(MAIN_WINDOW_WIDTH);
            mFrmMain.Height = ReadValueAsInt(MAIN_WINDOW_HEIHT);


            foreach (ColumnHeader col in mFrmMain.lstStorageItem.Columns)
            {
                col.Width = ReadValueAsInt("ColStorageItem" + col.Index);

            }

            int lSelectedIndex = ReadValueAsInt(STORAGE_ITEM_SELECTED_INDEX); ;
            if (lSelectedIndex == -1)
            {
                if (mFrmMain.lstStorageItem.Items.Count > 0)
                    mFrmMain.lstStorageItem.Items[0].Selected = true;

            }
            else
                if ((mFrmMain.lstStorageItem.Items.Count > 0) && (mFrmMain.lstStorageItem.Items.Count > lSelectedIndex))
                    mFrmMain.lstStorageItem.Items[lSelectedIndex].Selected = true;


            mFrmMain.splitContainer.SplitterDistance = ReadValueAsInt(mFrmMain.splitContainer.Name); ;
            mFrmMain.splitContainerTree.SplitterDistance = ReadValueAsInt(mFrmMain.splitContainerTree.Name); ;

            //foreach (ColumnHeader col in mFrmMain.lstRef.Columns)
            //{
            //    col.Width = ReadValueAsInt("mLstRef" + col.Index);

            //}
            //mFrmMain.splitContainerMainItem.SplitterDistance = ReadValueAsInt(SPLIT_CONTAINER_MAIN_ITEM); ;
            //mFrmMain.splitContainerRef.SplitterDistance = ReadValueAsInt(SPLIT_CONTAINER_REF);

            int lMainStorageItemID = ReadValueAsInt(MAIN_STORAGE_ITEM_ID);
            if (lMainStorageItemID != -1)
                mFrmMain.LoadMainStorageItemByID(lMainStorageItemID);
            //mFrmMain.splitContainerGroupBySite.SplitterDistance = ReadValueAsInt(mFrmMain.splitContainerGroupBySite.Name);
            mFrmMain.splitContainerReferenceTree.SplitterDistance = ReadValueAsInt(mFrmMain.splitContainerReferenceTree.Name);
            mFrmMain.splitContainerStorageItem.SplitterDistance = ReadValueAsInt(mFrmMain.splitContainerStorageItem.Name);
            mFrmMain.splitContainerSiteGroup.SplitterDistance = ReadValueAsInt(mFrmMain.splitContainerSiteGroup.Name);
            mFrmMain.ctrlReferenceNavigator.LoadFromString(ReadValueAsString(mFrmMain.ctrlReferenceNavigator.Name), false);
            if (lMainStorageItemID != -1)
                mFrmMain.ctrlReferenceNavigator.PutPositionForStorageItemID(lMainStorageItemID);

            mFrmMain.chkAllowLstStorageMultiSelect.Checked = bool.Parse(ReadValueAsString(mFrmMain.chkAllowLstStorageMultiSelect.Name));
            mFrmMain.chkClearPrevResult.Checked = bool.Parse(ReadValueAsString(mFrmMain.chkClearPrevResult.Name));
            mFrmMain.chkSearchInAllCategories.Checked = bool.Parse(ReadValueAsString(mFrmMain.chkSearchInAllCategories.Name));
            mFrmMain.splitContainerSimilarItems.SplitterDistance = ReadValueAsInt(mFrmMain.splitContainerSimilarItems.Name);
            mFrmMain.splitContainerGroupStorage.SplitterDistance = ReadValueAsInt(mFrmMain.splitContainerGroupStorage.Name);
            //mFrmMain.splitContainerAllQuickList.SplitterDistance = ReadValueAsInt(mFrmMain.splitContainerAllQuickList.Name);
            mFrmMain.cmbTopN.SelectedItem = ReadValueAsString(mFrmMain.cmbTopN.Name);
            Options.GetInstance().IsSameSiteLoadingEnabled = Convert.ToBoolean(ReadValueAsString("IsSameSiteLoadingEnabled"));
            Options.GetInstance().IsSimilarItemsLoad = Convert.ToBoolean(ReadValueAsString("IsSimilarItemsLoad"));
            Options.GetInstance().IsQuickListLoad = Convert.ToBoolean(ReadValueAsString("IsQuickListLoad"));
            Options.GetInstance().IsIDM = Convert.ToBoolean(ReadValueAsString("IsIDM"));
            mFrmMain.chkShowHint.Checked = bool.Parse(ReadValueAsString(mFrmMain.chkShowHint.Name));


        }

    }
}
