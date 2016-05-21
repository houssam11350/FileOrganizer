using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FileOrganizer.UI
{
    public partial class CtrlReferenceNavigator : UserControl
    {
        List<long> mStorageItemIDsList = new List<long>();
        int mPosition = -1;
        const int MAX_REFERENCES_COUNT = 50;

        public CtrlReferenceNavigator()
        {
            InitializeComponent();
        }

        public event ReferenceNavigatorPositionChangedEventHandler ReferenceNavigatorPositionChanged;
        public event EventHandler LocateClicked;


        [Browsable(false)]
        public long CurrentStorageItemID
        {
            get { return mStorageItemIDsList[mPosition]; }
        }

        private void DoReferenceNavigatorPositionChanged()
        {
            if (ReferenceNavigatorPositionChanged != null)
            {
                ReferenceNavigatorPositionChanged(this, new ReferenceNavigatorPositionChangedEventArgs(CurrentStorageItemID));
            }


        }
        private void tsbBack_Click(object sender, EventArgs e)
        {
            if (CanDoBack())
                DoBack();


        }

        private bool CanDoBack()
        {
            if (mStorageItemIDsList.Count == 0)
                return false;
            if (mPosition <= 0)
                return false;
            return true;
        }

        private void DoBack()
        {
            mPosition = mPosition - 1;
            EnableDisableButtons();

            DoReferenceNavigatorPositionChanged();
        }

        private void EnableDisableButtons()
        {
            if (mStorageItemIDsList.Count == 0)
            {
                tsbBack.Enabled = false;
                tsbForward.Enabled = false;
                tsbLocate.Enabled = false;
                return;
            }
            tsbLocate.Enabled = true;

            if (mPosition <= 0)
                tsbBack.Enabled = false;
            else
                tsbBack.Enabled = true;



            if (mPosition >= mStorageItemIDsList.Count - 1)
                tsbForward.Enabled = false;
            else
                tsbForward.Enabled = true;





        }



        private void tsbForward_Click(object sender, EventArgs e)
        {
            if (CanForward())
                DoForward();


        }

        private bool CanForward()
        {
            if (mStorageItemIDsList.Count == 0)
                return false;
            if (mPosition >= mStorageItemIDsList.Count - 1)
                return false;
            return true;
        }

        private void DoForward()
        {
            mPosition = mPosition + 1;
            EnableDisableButtons();

            DoReferenceNavigatorPositionChanged();
        }

        public string GetStorageItemIDsAsString()
        {
            //string[] s 
            //mStorageItemIDsList.ToArray().Join(
            //string.Join(",", (string[])mStorageItemIDsList.ToArray(Type.GetType("System.String")));

            string iDListStr = string.Join(",", Array.ConvertAll<long, string>(mStorageItemIDsList.ToArray(), Convert.ToString));
            return iDListStr;
        }


        public void LoadFromString(string pStorageItemIDsStr, bool pIsToHanldePosition)
        {
            mStorageItemIDsList = new List<long>();
            string[] storageItemIDArr = pStorageItemIDsStr.Split(',');
            foreach (string sStorageItemID in storageItemIDArr)
            {
                if (!string.IsNullOrEmpty(sStorageItemID))
                    mStorageItemIDsList.Add(Convert.ToInt32(sStorageItemID));
            }

            if (pIsToHanldePosition)
                if (mStorageItemIDsList.Count > 0)
                {

                    mPosition = 0;
                    DoReferenceNavigatorPositionChanged();
                    EnableDisableButtons();
                }



        }


        public void PutPositionForStorageItemID(long pStorageItemID)
        {
            bool isFound = false;
            for (int index = 0; index < mStorageItemIDsList.Count; index++)
            {
                if (mStorageItemIDsList[index] == pStorageItemID)
                {
                    isFound = true;
                    mPosition = index;
                    break;
                }
            }


            if (isFound)
            {
                //put current item at last
                if (mPosition != -1 && mStorageItemIDsList.Count > 0)
                {
                    long storageItemID = mStorageItemIDsList[mPosition];
                    mStorageItemIDsList.RemoveAt(mPosition);
                    mStorageItemIDsList.Add(storageItemID);
                    mPosition = mStorageItemIDsList.Count - 1;
                }

            }


            if (!isFound)
            {
                if (mStorageItemIDsList.Count == MAX_REFERENCES_COUNT)
                    mStorageItemIDsList.RemoveAt(0);
                //put current item at last
                if (mPosition != -1 && mStorageItemIDsList.Count > 0)
                {
                    long storageItemID = mStorageItemIDsList[mPosition];
                    mStorageItemIDsList.RemoveAt(mPosition);
                    mStorageItemIDsList.Add(storageItemID);
                }
                //add the new item
                mStorageItemIDsList.Add(pStorageItemID);
                mPosition = mStorageItemIDsList.Count - 1;
            }
            DoReferenceNavigatorPositionChanged();
            EnableDisableButtons();

        }

        private void tsbLocate_Click(object sender, EventArgs e)
        {
            
            if (LocateClicked != null)
                LocateClicked(sender, e);
        }

    }
    public delegate void ReferenceNavigatorPositionChangedEventHandler(object sender, ReferenceNavigatorPositionChangedEventArgs e);
    public class ReferenceNavigatorPositionChangedEventArgs : EventArgs
    {
        long mStorageItemID = -1;
        public long StorageItemID
        {
            get { return mStorageItemID; }
            // set { mStorageItemID = value; }
        }

        public ReferenceNavigatorPositionChangedEventArgs(long pStorageItemID)
        {
            mStorageItemID = pStorageItemID;
        }
    }

}
